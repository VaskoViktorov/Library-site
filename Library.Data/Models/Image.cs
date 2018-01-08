namespace Library.Data.Models
{
   public class Image
    {
        public int Id { get; set; }

        public byte[] ImageString { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public int GalleryId { get; set; }

        public Gallery Gallery { get; set; }

    }
}
