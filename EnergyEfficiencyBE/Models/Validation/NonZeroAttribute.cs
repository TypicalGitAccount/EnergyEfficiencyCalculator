using System.ComponentModel.DataAnnotations;

namespace EnergyEfficiencyBE.Models.Validation
{
    public class NonZeroAttribute : ValidationAttribute
    {
        private readonly string _fieldName;

        public NonZeroAttribute(string fieldName) {  _fieldName = fieldName; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDecimal(value) > 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"Значення поля {_fieldName} має бути більше 0!");
        }
    }
}
