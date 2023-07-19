using System.Net;
using System.Net.Mail;

namespace View.Services;

public class EmailService
{
    public void SendEmail(string recipientEmail, string subject, string body)
    {
        var smtpClient = new SmtpClient(SettingsProvider.EmailHost)
        {
            Port = SettingsProvider.EmailPort,
            Credentials = new NetworkCredential(SettingsProvider.EmailUsername, SettingsProvider.EmailPassword),
            EnableSsl = SettingsProvider.EmailEnableSsl,
        };
    
        smtpClient.Send(SettingsProvider.EmailFrom, recipientEmail, subject, body);
    }
}