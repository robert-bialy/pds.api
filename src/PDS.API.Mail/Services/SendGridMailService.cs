using SendGrid;
using SendGrid.Helpers.Mail;

namespace PDS.API.Mail.Services;

public sealed class SendGridMailService : IMailService
{
    public async Task<bool> SendEmail(string receiverEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(receiverEmail)) throw new ArgumentNullException(nameof(receiverEmail));
        if (string.IsNullOrEmpty(subject)) throw new ArgumentNullException(nameof(subject));

        var apiKey = "";
        var fromEmailAddress = "robert@madmax.consulting";
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress(fromEmailAddress);
        var to = new EmailAddress(receiverEmail);

        var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, message, null);

        var result = await client.SendEmailAsync(sendGridMessage);

        return result.IsSuccessStatusCode;
    }
}