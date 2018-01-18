namespace Library.Web.Models.Home
{
    using System.ComponentModel.DataAnnotations;

    public class AskFormModel
    {
        [MinLength(0)]
        [MaxLength(100)]
        [Display(Name = "Имейл")]
        public string Email { get; set; } = "-";

        [MinLength(0)]
        [MaxLength(30)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; } = "-";

        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        [Display(Name = "Име, Фамилия")]
        public string UserInfo { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(5000)]
        [Display(Name = "Въпрос")]
        public string Description { get; set; }
    }
}
