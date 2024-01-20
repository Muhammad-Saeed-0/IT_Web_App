using webApp.Utility;

namespace webApp.Repository.Contracts
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}
