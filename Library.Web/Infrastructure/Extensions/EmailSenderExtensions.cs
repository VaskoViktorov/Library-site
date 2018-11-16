namespace Library.Web.Infrastructure.Extensions
{
    using Services;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using static WebConstants;

    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, EmailReceiverConfirmation,
               string.Format(EmailReceiverMessage, HtmlEncoder.Default.Encode(link)));
        }

        public static Task SendEmailWithQuestionAsync(this IEmailSender emailSender, string email, string html, string heading)
        {
            return emailSender.SendEmailAsync(email, heading, html);
        }
    }
}