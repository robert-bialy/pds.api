namespace PDS.API.Mail.Services;

public interface IMailService
{
    Task SendEmail(string email, string message);
}