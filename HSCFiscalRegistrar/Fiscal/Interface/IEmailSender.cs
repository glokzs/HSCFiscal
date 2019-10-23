using System.Threading.Tasks;

namespace Fiscal.Interface
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}