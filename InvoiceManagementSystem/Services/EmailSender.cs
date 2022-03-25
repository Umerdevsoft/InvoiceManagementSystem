using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using InvoiceManagementSystem.ViewModels;


namespace InvoiceManagementSystem.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(email));//------
                message.From = new MailAddress("demostreetware@gmail.com");
                message.Subject = "Test";
                message.Body = htmlMessage;
                message.IsBodyHtml = true;


                using (SmtpClient client = new SmtpClient())
                {

                    client.Host = "smtp.gmail.com";
                    client.UseDefaultCredentials = false;
                    NetworkCredential networkCredential = new NetworkCredential("demostreetware@gmail.com", "Admin@1234");
                    client.Credentials = networkCredential;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.Port = 587;
                    client.Send(message);

                }
            }
            return Task.CompletedTask;
        }

    }
}


