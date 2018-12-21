namespace Library.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Net.Http.Headers;
    using System.IO;
    using System.Threading.Tasks;

    public static class FormFileExtensions
    {
        public static string GetFileType(this IFormFile file)
        {
            var fileName = ContentDispositionHeaderValue.Parse(
                 file.ContentDisposition).FileName.ToString().Trim('"');

            return fileName.Substring(fileName.Length - 4, 4);
        }

        public static async Task<MemoryStream> GetFileStream(this IFormFile file)
        {
            MemoryStream filestream = new MemoryStream();
            await file.CopyToAsync(filestream);
            return filestream;
        }

        public static async Task<byte[]> GetFileArray(this IFormFile file)
        {
            MemoryStream filestream = new MemoryStream();
            await file.CopyToAsync(filestream);
            return filestream.ToArray();
        }

        public static string ReadTxtFile(string path)
        {
            path = string.Format(path, Directory.GetCurrentDirectory());
          return File.ReadAllText(path);
        }
    }
}