using System.ComponentModel.DataAnnotations;

namespace Loan.Framework.Commons.Utilities
{
    [AttributeUsage(AttributeTargets.Property |
  AttributeTargets.Field, AllowMultiple = false)]
    public class NationalCodeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var valueAsString = value as string;
            return valueAsString.IsValidNationalCode();
        }
    }
}
