using System.Net;
using System.Net.Mail;
using System.Transactions;
using Microsoft.AspNetCore.Components;
using Model.Entities.Email;

namespace View.Services;

public class EmailService
{
    #region Fields

    private readonly IUserRepository _userRepository;
    private readonly IEmailTemplateRepository _emailTemplateRepository;
    private readonly NavigationManager _navigationManager;
    private readonly NavigationProvider _navigationProvider;

    #endregion

    #region Ctor

    public EmailService(IUserRepository userRepository, IEmailTemplateRepository emailTemplateRepository, NavigationManager navigationManager, NavigationProvider navigationProvider)
    {
        _userRepository = userRepository;
        _emailTemplateRepository = emailTemplateRepository;
        _navigationManager = navigationManager;
        _navigationProvider = navigationProvider;
    }

    #endregion

    #region Methods

    public async Task SendEmail(string recipientEmail, string subject, string body)
    {
        try
        {
            var smtpClient = new SmtpClient(SettingsProvider.EmailHost)
            {
                Port = SettingsProvider.EmailPort,
                Credentials = new NetworkCredential(SettingsProvider.EmailUsername, SettingsProvider.EmailPassword),
                EnableSsl = SettingsProvider.EmailEnableSsl,
            };

            var message = new MailMessage();
            message.To.Add(recipientEmail);
            message.From = new MailAddress(SettingsProvider.EmailFrom);
            message.Subject = subject;

            message.IsBodyHtml = true;
            message.Body = body;

            smtpClient.Send(message);
        }
        catch (Exception e)
        {
            throw new EmailSendingException();
        }
    }

    public async Task SendEmail(TemplateType templateType, IEnumerable<User> users)
    {
        var template = await GetTemplate(templateType);

        foreach (var user in users)
        {
            await SendEmail(user.Email, template.Subject, template.Body.Replace("#email-username#", user.Username));
        }

    }
    
    public async Task SendEmail(TemplateType templateType, params User[] users) => await SendEmail(templateType, users.ToList());

    public async Task SendEmail(TemplateType templateType, IEnumerable<string> recipientEmails)
    {
        var users = await _userRepository.ReadAsync(u => recipientEmails.Contains(u.Email));
        await SendEmail(templateType, users);
    }

    public async Task SendEmail(TemplateType templateType, params string[] recipientEmails) => await SendEmail(templateType, recipientEmails.ToList());

    public async Task<EmailTemplate> GetTemplate(TemplateType templateType)
    {
        var template = (await _emailTemplateRepository.ReadAsync(et => et.TemplateType == templateType)).FirstOrDefault();

        if (template == null) throw new ArgumentNullException();

        template.Subject = ReplaceEmailTokens(template.Subject);
        template.Body = ReplaceEmailTokens(
            File.ReadAllText("wwwroot/html/email-templates/header.html") +
            File.ReadAllText(template.PathToBody) +
            File.ReadAllText("wwwroot/html/email-templates/footer.html"));
        
        return template;
    }

    public string ReplaceEmailTokens(string message)
    {
        return message
            .Replace("#email-application-name#", SettingsProvider.EmailApplicationName)
            .Replace("#email-application-url#", SettingsProvider.EmailApplicationUrl)
            .Replace("#email-application-logo#", SettingsProvider.EmailApplicationLogo)
            
            .Replace("#email-header-text#", SettingsProvider.EmailCompanySlogan)
            .Replace("#email-company-address#", SettingsProvider.EmailCompanyAddress)
            
            .Replace("#email-application-log-in-link#", _navigationManager.BaseUri + _navigationProvider["Login"].Link)
            .Replace("#email-application-register-link#", _navigationManager.BaseUri + _navigationProvider["Register"].Link)
            .Replace("#email-application-admin-user-registration-link#", _navigationManager.BaseUri + _navigationProvider["Inactive Users"].Link);
    }

    #endregion
}