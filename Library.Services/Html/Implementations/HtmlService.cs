namespace Library.Services.Html.Implementations
{
    using Ganss.XSS;

    using static ServicesConstants;

    class HtmlService : IHtmlService
    {
        private const string ClassAttribute = ClassAttributeType;

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