namespace Library.Data.Models
{
    using System.Collections.Generic;

    public class Gallery
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Image> Images { get; set; } = new List<Image>();
    }
}
