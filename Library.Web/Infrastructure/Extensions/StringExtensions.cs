namespace Library.Web.Infrastructure.Extensions
{
    using System;
    using Data.Models;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// changes the url text to user friendly url(only words, digits and dashes)
    /// </summary>
    public static class StringExtensions
    {
        public static string ToFriendlyUrl(this string text)
            => Regex.Replace(text, @"[^A-Za-z0-9_\.~]+", "-").ToLower();

        public static bool IsNullOrWhiteSpace(string text)
            => string.IsNullOrWhiteSpace(text);

        public static string LimitStringLenght(this string text, int maxLenght)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (text.Length > maxLenght)
                {
                    return text.Substring(0, maxLenght) + "...";
                }
            }

            return text;
        }

        public static string DepartmentsToBgLang(this DepartmentType text)
        {
            switch (text)
            {
                case DepartmentType.Kids:
                    return "Детски";
                case DepartmentType.Rent:
                    return "Заемна";
                case DepartmentType.Read:
                    return "Читални";
                case DepartmentType.Check:
                    return "Справочен";
                case DepartmentType.Art:
                    return "Изкуство";
                case DepartmentType.Land:
                    return "Краезнание";
            }

            return String.Empty;
        }

        //Extracts text from html
        public static string TruncateHtml(this string html, int maxCharacters, string trailingText)
        {
            if (string.IsNullOrEmpty(html))
                return html;

            // find the spot to truncate
            // count the text characters and ignore tags
            var textCount = 0;
            var charCount = 0;
            var ignore = false;
            foreach (char c in html)
            {
                charCount++;
                if (c == '<')
                    ignore = true;
                else if (!ignore)
                    textCount++;

                if (c == '>')
                    ignore = false;

                // stop once we hit the limit
                if (textCount >= maxCharacters)
                    break;
            }

            // Truncate the html and keep whole words only
            var trunc = new StringBuilder(html.TruncateWords(charCount));

            // keep track of open tags and close any tags left open
            var tags = new Stack<string>();
            var matches = Regex.Matches(trunc.ToString(),
                @"<((?<tag>[^\s/>]+)|/(?<closeTag>[^\s>]+)).*?(?<selfClose>/)?\s*>",
                RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Multiline);

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    var tag = match.Groups["tag"].Value;
                    var closeTag = match.Groups["closeTag"].Value;

                    // push to stack if open tag and ignore it if it is self-closing, i.e. <br />
                    if (!string.IsNullOrEmpty(tag) && string.IsNullOrEmpty(match.Groups["selfClose"].Value))
                        tags.Push(tag);

                    // pop from stack if close tag
                    else if (!string.IsNullOrEmpty(closeTag))
                    {
                        // pop the tag to close it.. find the matching opening tag
                        // ignore any unclosed tags
                        while (tags.Pop() != closeTag && tags.Count > 0)
                        { }
                    }
                }
            }

            if (html.Length > charCount)
                // add the trailing text
                trunc.Append(trailingText);

            // pop the rest off the stack to close remainder of tags
            while (tags.Count > 0)
            {
                trunc.Append("</");
                trunc.Append(tags.Pop());
                trunc.Append('>');
            }

            return trunc.ToString();
        }

        /// <summary>
        /// Truncates a string containing HTML to a number of text characters, keeping whole words.
        /// The result contains HTML and any tags left open are closed.
        /// </summary>
        public static string TruncateHtml(this string html, int maxCharacters)
        {
            return html.TruncateHtml(maxCharacters, null);
        }

        /// <summary>
        /// Truncates a string containing HTML to the first occurrence of a delimiter
        /// </summary>
        /// <param name="html">The HTML string to truncate</param>
        /// <param name="delimiter">The delimiter</param>
        /// <param name="comparison">The delimiter comparison type</param>
        /// <returns></returns>
        public static string TruncateHtmlByDelimiter(this string html, string delimiter, StringComparison comparison = StringComparison.Ordinal)
        {
            var index = html.IndexOf(delimiter, comparison);
            if (index <= 0) return html;

            var r = html.Substring(0, index);
            return r.TruncateHtml(r.StripHtml().Length);
        }

        /// <summary>
        /// Strips all HTML tags from a string
        /// </summary>
        public static string StripHtml(this string html)
        {
            if (string.IsNullOrEmpty(html))
                return html;

            return Regex.Replace(html, @"<(.|\n)*?>", string.Empty);
        }

        /// <summary>
        /// Truncates text to a number of characters
        /// </summary>
        public static string Truncate(this string text, int maxCharacters)
        {
            return text.Truncate(maxCharacters, null);
        }

        /// <summary>
        /// Truncates text to a number of characters and adds trailing text, i.e. elipses, to the end
        /// </summary>
        public static string Truncate(this string text, int maxCharacters, string trailingText)
        {
            if (string.IsNullOrEmpty(text) || maxCharacters <= 0 || text.Length <= maxCharacters)
                return text;
            else
                return text.Substring(0, maxCharacters) + trailingText;
        }


        /// <summary>
        /// Truncates text and discars any partial words left at the end
        /// </summary>
        public static string TruncateWords(this string text, int maxCharacters)
        {
            return text.TruncateWords(maxCharacters, null);
        }

        /// <summary>
        /// Truncates text and discars any partial words left at the end
        /// </summary>
        public static string TruncateWords(this string text, int maxCharacters, string trailingText)
        {
            if (string.IsNullOrEmpty(text) || maxCharacters <= 0 || text.Length <= maxCharacters)
                return text;

            // trunctate the text, then remove the partial word at the end
            return Regex.Replace(text.Truncate(maxCharacters),
                @"\s+[^\s]+$", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled) + trailingText;
        }
    }
}

