namespace Library.Services.Html.Implementations
{
    using Ganss.XSS;

    class HtmlService : IHtmlService
    {
        private const string ClassAttribute = "class";

        private readonly HtmlSanitizer htmlSanitizer;

        public HtmlService()
        {
            this.htmlSanitizer = new HtmlSanitizer();
            this.htmlSanitizer.AllowedAttributes.Add(ClassAttribute);
        }

        public string Sanitize(string htmlContent)
            => this.htmlSanitizer.Sanitize(htmlContent);
    }
}