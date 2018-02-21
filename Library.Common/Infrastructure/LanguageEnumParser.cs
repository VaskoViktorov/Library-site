namespace Library.Common.Infrastructure
{
    public static class LanguageEnumParser
    {
        public static int ParseLang(this string value)
        {
            if (value == "bg-BG")
            {
                return 0;
            }

            return 1;
        }
    }
}
