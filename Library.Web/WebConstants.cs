namespace Library.Web
{
    public class WebConstants
    {
        public const string AdministratorRole = "Administrator";
        public const string LibrarianAuthorRole = "Librarian";

        public const string TempDataSuccessMessageKey = "SuccessMessage";
        public const string TempDataWarningMessageKey = "WarningMessage";

        public const string TempDataDeleteCommentText = "{0} е изтрит{1} успешно.";
        public const string TempDataEditCommentText = "{0} е редактиран{1} успешно.";
        public const string TempDataCreateCommentText = "{0} е създаден{1} успешно.";

        public const string TempDataCreateFailText = "Възникна грешка!{0} НЕ е създаден{1}.";
        public const string TempDataEditFailText = "Възникна грешка!{0} НЕ е редактиран{1}.";
        public const string TempDataDeleteFailText = "Възникна грешка!{0} НЕ е изтрит{1}.";

        public const string TempDataAlreadyExistsText = "{0} с име {1}, вече съществува.";
        public const string TempDataWrongUrlText = "НЕ е създадена {0}, поради грешен URL адрес.";

        public const string AdminAreaName = "Admin";
        public const string LibraryAreaName = "LibraryBlog";
        public const string EnglishAreaName = "En";

        public const string BulgarianLanguage = "bg";
        public const string EnglishLanguage = "en";

        public const string EmailReceiverForAsk = "rbmg@abv.bg";
        public const string EmailReceiverHtmlText = @"<div style='width: 500px;'>
            <p style = 'font-weight: bold; text-align: left; margin-bottom: 15px;'> Въпрос </ p >
            <p style='text-align: justify;margin-bottom: 30px;'>{0}</p>
            <p style = 'font-weight: bold; text-align: left;margin-bottom: 15px;'> Информация за обратна връзка</p>
            <p style = 'text-align: left;margin-bottom: 5px;'><span style='font-weight: bold' > Телефон: </span>{1}</p>
            <p style = 'text-align: left;margin-bottom: 5px;'><span style='font-weight: bold'>Имейл:  </span>{2}</p>
            <p style = 'text-align: left;'><span style='font-weight: bold'> Име: </span>{3}</p>
            </div>";

        public const string CallendarJasonDbPath = "{0}\\wwwroot\\lib\\jquery\\dist\\EventsDb.json";
        public const string SurveysJasonDbPath = "{0}\\wwwroot\\json\\SurveysDb.json";
        public const string SurveysEnJasonDbPath = "{0}\\wwwroot\\json\\SurveysEnDb.json";
    }
}