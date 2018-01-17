namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Subscription
    {
        public int Id { get; set; }

        [Required]      
        [MinLength(SubscriptionNameMinLength)]
        [MaxLength(SubscriptionNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public DepartmentType Department { get; set; }

        [Required]
        public SubscriptionType Type { get; set; }
    }
}
