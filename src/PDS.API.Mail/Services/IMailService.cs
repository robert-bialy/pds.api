namespace PDS.API.Mail.Services;

public interface IMailService
{
    Task<bool> SendEmail(string email, string subject, string message);
}