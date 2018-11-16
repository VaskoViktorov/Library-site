using Library.Data.Models;

namespace Library.Web
{
    public class WebConstants
    {
        //Area names
        public const string AdminAreaName = "Admin";
        public const string LibraryAreaName = "LibraryBlog";

        //Role names
        public const string AdministratorRole = "Administrator";
        public const string LibrarianAuthorRole = "Librarian";

        //UserController strings
        public const string ErrorMsgInvalidIdentity = "Invalid identity details.";
        public const string AddRequestKey = "add";
        public const string RemoveRequestKey = "remove";
        public const string WarrningUserAlreadyInRole = "User {0} is already in {1} role.";
        public const string SuccessUserAddedToRole = "User {0} successfully added to the {1} role.";
        public const string WarrningUserNotInRole = "User {0} is not in {1} role.";
        public const string SuccessUserRemovedFromRole = "User {0} is no longer {1}.";


        //Department names
        public const string KidsDepartment = "Детски";
        public const string RentDepartment = "Заемна";
        public const string ReadDepartment = "Читални";
        public const string CheckDepartment = "Справочен";
        public const string ArtDepartment = "Изкуство";
        public const string LandDepartment = "Краезнание";
        public const string ForeignDepartment = "Чуждоезиков";

        //Culture short/long name
        public const string BulgarianLanguage = "bg";
        public const string BulgarianCulture = "bg-BG";
        public const string EnglishLanguage = "en";
        public const string EnglishCulture = "en-US";

        //Sent email info for Ask the librarian
        public const string EmailReceiverForAsk = "rbmg@abv.bg";
        public const string EmailHeadingForAsk = "Въпрос от \"Попитай библиотекаря\"";
        public const string EmailReceiverHtmlTextAsk = @"<div style='width: 500px;'>
            <p style = 'font-weight: bold; text-align: left; margin-bottom: 15px;'> Въпрос </ p >
            <p style='text-align: justify;margin-bottom: 30px;'>{0}</p>
            <p style = 'font-weight: bold; text-align: left;margin-bottom: 15px;'> Информация за обратна връзка</p>
            <p style = 'text-align: left;margin-bottom: 5px;'><span style='font-weight: bold' > Телефон: </span>{1}</p>
            <p style = 'text-align: left;margin-bottom: 5px;'><span style='font-weight: bold'>Имейл:  </span>{2}</p>
            <p style = 'text-align: left;'><span style='font-weight: bold'> Име: </span>{3}</p>
            </div>";

        //Sent email info for Book borrow period extending 
        public const string EmailRecieverForExtendPeriod = "zaemna_vidin@abv.bg";
        public const string EmailHeadingForExtendPeriod = "Заявка за презаписване";
        public const string EmailReceiverHtmlTextExtendPeriod = @" <div style='width: 500px;'>
            <p style='font-weight: bold; text-align: left; margin-bottom: 15px;'>Информация за презаписване:</p>
            <p style='text-align: left;margin-bottom: 5px;'><span style='font-weight: bold'>Номер на карта: </span>{1}</p>
            <p style='text-align: left;margin-bottom: 5px;'><span style='font-weight: bold'>Инв. номер, Книга, Автор: </span>{0}</p>
            <p style='font-weight: bold; text-align: left;margin-bottom: 15px;margin-top: 15px;'>Информация за обратна връзка:</p>            
            <p style='text-align: left;'><span style='font-weight: bold'>Име: </span>{3}</p>
            <p style='text-align: left;margin-bottom: 5px;'><span style='font-weight: bold'>Имейл: </span>{2}</p>  
            </div>";

        //Sent email info for account activation
        public const string EmailReceiverConfirmation = "Confirm your email";
        public const string EmailReceiverMessage = "Моля потвърдете акаунта си: <a href='{0}'>link</a>";

        //Directory paths
        public const string CallendarJasonDbPath = "{0}\\wwwroot\\json\\EventsDb.json";
        public const string SurveysJasonDbPath = "{0}\\wwwroot\\json\\SurveysDb.json";
        public const string SurveysEnJasonDbPath = "{0}\\wwwroot\\json\\SurveysEnDb.json";
        public const string DefaultImagePath = "/images/BookCovers/default.jpg";
        public const string SavePath = "/{0}";
        public const string SitemapPath = "\\wwwroot\\sitemap.xml";
        public const string RobotsPath = "\\wwwroot\\Robots.txt";

        //Folder names
        public const string RootFolderName = "wwwroot";
        public const string ImageFolderName = "images";
        public const string GalleriesImageFolderName = "GalleryImages";
        public const string BooksImageFolderName = "BookCovers";

        //File types
        public const string TextOrXmlFileType = "text/xml";
        public const string JpgType = ".jpg";
        public const string GifType = ".gif";
        public const string PngType = ".png";

        //Error messages
        public const string NoSelectedFiles = "Files not selected.";

        //Books filter names
        public const string BooksFilter = "Books";
        public const string BooksForKidsFilter = "BooksForKids";
        public const string BooksForLandFilter = "BooksForLand";

        //LibraryBlog model message name in bg for temp data
        public const string BookBgModelName = "Книгата";
        public const string ArticleBgModelName = "Статията";
        public const string EventBgModelName = "Събитието";
        public const string GalleryBgModelName = "Галерията";
        public const string SubscriptionBgModelName = "Абонамента";
        public const string SurveyBgModelName = "Анкетата";

        //Home model message name in bg for temp data
        public const string AskBgModelName = "Въпросът";
        public const string ExtendPeriodBgModelName = "Заявката";

        //Word endings in bg
        public const string EndingLetterA = "a";
        public const string EndingLetterO = "o";

        //Temp data type names
        public const string TempDataSuccessMessageKey = "SuccessMessage";
        public const string TempDataWarningMessageKey = "WarningMessage";

        //Temp data bg messages
        public const string TempDataSearchEmtyTextMessage = "Полето за текст е празно.";
        public const string TempDataSearchNoSelectMessage = "Няма селектиран критерии за търсене.";
        public const string TempDataDeleteCommentText = "{0} е изтрит{1} успешно.";
        public const string TempDataEditCommentText = "{0} е редактиран{1} успешно.";
        public const string TempDataCreateCommentText = "{0} е създаден{1} успешно.";
        public const string TempDataCreateFailText = "Възникна грешка!{0} НЕ е създаден{1}.";
        public const string TempDataEditFailText = "Възникна грешка!{0} НЕ е редактиран{1}.";
        public const string TempDataDeleteFailText = "Възникна грешка!{0} НЕ е изтрит{1}.";
        public const string TempDataAlreadyExistsText = "{0} с име {1}, вече съществува.";
        public const string TempDataWrongUrlText = "{0} НЕ е създадена, поради грешен URL адрес.";
        public const string TempDataSendEmailText = "{0} е изпратен{1} успешно.";

        //Other
        public const string GetMethodRequest = "GET";
        public const string InterfaceName = "I{0}";
        public const string ModelName = "model";
        public const string AppDomainName = "Library";
        public const string WwwName = "www.";
    }
}