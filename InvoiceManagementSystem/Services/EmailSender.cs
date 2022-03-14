using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(email));//------
                message.From = new MailAddress("Umersoft11@gmail.com", "Umer");
                message.Subject = "Test";
                message.Body = htmlMessage;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;

                using (var client = new SmtpClient())
                {

                    client.Host = "smtp-relay.sendinblue.com";
                    client.Port = 587;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("Umersoft11@gmail.com", "dtuqdzbqkcjarqst");
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
            return Task.CompletedTask;
        }

    }
}


