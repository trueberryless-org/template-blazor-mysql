using System.Net;
using System.Net.Mail;
using Model.Entities.Email;

namespace View.Services;

public class EmailService
{
    #region Fields

    private readonly IUserRepository _userRepository;

    #endregion

    #region Ctor

    public EmailService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    #endregion
    
    public async Task SendEmail(string recipientEmail, string subject, string body)
    {
        var smtpClient = new SmtpClient(SettingsProvider.EmailHost)
        {
            Port = SettingsProvider.EmailPort,
            Credentials = new NetworkCredential(SettingsProvider.EmailUsername, SettingsProvider.EmailPassword),
            EnableSsl = SettingsProvider.EmailEnableSsl,
        };
    
        smtpClient.Send(SettingsProvider.EmailFrom, recipientEmail, subject, body);
    }

    public async Task SendEmail(TemplateType templateType, string recipientEmail)
    {
        try
        {
            var user = await _userRepository.FindByEmailAsync(recipientEmail);

            switch (templateType)
            {
                case TemplateType.USER_REGISTRATION_COMPLETE:
                    var template = EmailTemplates[templateType];
                    await SendEmail(recipientEmail, template.Subject,
                        template.Body
                            .Replace("#email-username#", user.Username)

                    );
                    break;
            }
        }
        catch (Exception e)
        {
            // ignored
        }
    }

    // TODO: Extract in db
    public Dictionary<TemplateType, EmailTemplate> EmailTemplates = new()
    {
        {
            TemplateType.USER_REGISTRATION_COMPLETE,
            new EmailTemplate()
            {
                Subject = $"{SettingsProvider.ApplicationName}: Registration complete!",
                Body = File.ReadAllText("~/wwwroot/html/email-templates/user-registration-complete.html")
                    .Replace("#email-application-url#", SettingsProvider.EmailApplicationUrl)
                    .Replace("#email-application-logo#", SettingsProvider.EmailApplicationLogo)
                    .Replace("#email-header-text#", SettingsProvider.EmailHeaderText)
                    .Replace("#email-application-log-in-page#", SettingsProvider.EmailApplicationLogInPage)
                    .Replace("#email-company-address#", SettingsProvider.EmailCompanyAddress)
            }
        }
    };
}