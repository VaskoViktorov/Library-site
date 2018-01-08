namespace Library.Data.Models
{
    using System;

    public class Room
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string TimePreference { get; set; }
       
        public string Title { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
