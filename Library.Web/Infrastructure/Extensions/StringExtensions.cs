namespace Library.Web.Infrastructure.Extensions
{
    using System;
    using Data.Models;
    using System.Text.RegularExpressions;

    /// <summary>
    /// changes the url text to user friendly url(only words, digits and dashes)
    /// </summary>
    public static class StringExtensions
    {
        public static string ToFriendlyUrl(this string text)
            => Regex.Replace(text, @"[^A-Za-z0-9_\.~]+", "-").ToLower();

        public static bool IsNullOrWhiteSpace(string text)
            => string.IsNullOrWhiteSpace(text);

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
    }
}
