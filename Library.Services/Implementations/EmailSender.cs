using System;
using System.Net;
using System.Net.Mail;
using Library.Services.Models.EmailSender;
using Microsoft.Extensions.Options;

namespace Library.Services.Implementations
{
    using System.Threading.Tasks;

    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }              

        public AuthMessageSenderOptions Options { get; } 

        public Task SendEmailAsync(string email, string subject, string message)
        {
           this.Execute(email, subject, message).Wait();
            return Task.FromResult(0);
            
        }

        public async Task Execute(string email, string message, string subject)
        {
            try
            {
                string toEmail = string.IsNullOrEmpty(email)
                    ? Options.ToEmail
                    : email;
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(Options.UsernameEmail, "RB \"Mihalaki Georgiev\", Vidin")
                };
                mail.To.Add(new MailAddress(toEmail));
               

                mail.Subject = message;
                mail.Body = subject;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(Options.PrimaryDomain, Options.PrimaryPort))
                {
                    
                    smtp.Credentials = new NetworkCredential(Options.UsernameEmail, Options.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception)
            {
                //do something here
            }
        }
    }
}
