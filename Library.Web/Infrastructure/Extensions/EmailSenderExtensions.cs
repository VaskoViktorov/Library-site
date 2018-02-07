namespace Library.Web.Infrastructure.Extensions
{
    using Services;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Моля подтвърдете акаунта си: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }

        public static Task SendEmailWithQuestionAsync(this IEmailSender emailSender, string email, string html)
        {
            return emailSender.SendEmailAsync(email, "Vupros ot \"Popitai bibliotekara\"", html);
        }
    }
}