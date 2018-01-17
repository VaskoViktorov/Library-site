namespace Library.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Room
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string TimePreference { get; set; }      

        [Required]
        public string Description { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
