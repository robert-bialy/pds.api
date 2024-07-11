using SendGrid;
using SendGrid.Helpers.Mail;

namespace PDS.API.Mail.Services;

internal sealed class SendGridMailService : IMailService
{
    public async Task SendEmail(string email, string message)
    {
        var apiKey = "";
        var fromEmailAddress = "";
        var toEmailAddress = "";
        var subject = "";
        var client = new SendGridClient(apiKey);

        var from = new EmailAddress(fromEmailAddress);
        var to = new EmailAddress(toEmailAddress);
        var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, message, null);

        await client.SendEmailAsync(sendGridMessage);
    }
}