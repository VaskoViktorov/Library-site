namespace Library.Common.Infrastructure.Extensions
{
    using System.IO;

    public class FileExtensions
    {
        public static void  DeleteImage(string imagePath)
        {
            var startupPath = Path.GetFullPath(".\\");
            var filePath = $"{startupPath}\\wwwroot\\{imagePath}";

            if (File.Exists(filePath))
            {
                try
                {

                    File.Delete(filePath);
                }
                catch (IOException)
                {
                    return;
                }
            }
        }
    }
}
