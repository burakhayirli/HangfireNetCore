using System.Threading.Tasks;

namespace Hangfire.Web.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task Sender(string userId, string message)
        {
            System.Console.WriteLine($"Email Sent to userId: {userId}");

        }
    }
}
