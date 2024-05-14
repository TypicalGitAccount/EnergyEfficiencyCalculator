using System.ComponentModel.DataAnnotations;

namespace EnergyEfficiencyBE.Models.Validation
{
    public class SpecificValuesAttribute<T> : ValidationAttribute
    {
        private readonly T[] _values;

        public SpecificValuesAttribute(T[] values)
        {
            _values = values;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var val = (T)value;
            return value != null && _values.Contains(val) ? ValidationResult.Success!
                : new ValidationResult(ErrorMessage ?? $"Значення мусить входити в список: '{string.Join(", ", _values)}'.");
        }
    }
}
