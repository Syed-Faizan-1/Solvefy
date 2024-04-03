using Microsoft.AspNetCore.Identity.UI.Services;

namespace Product_Inventory
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Logic to send email
            return Task.CompletedTask;
        }
    }
}
