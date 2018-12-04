using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Infrastructure.Filters
{
    public class ValidateArticleReleaseDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return DateTime.Now >= (DateTime)value;
        }
    }
}
