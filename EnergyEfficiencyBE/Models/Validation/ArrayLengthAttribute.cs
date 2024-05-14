using System.ComponentModel.DataAnnotations;

namespace EnergyEfficiencyBE.Models.Validation
{
    public class ArrayLengthAttribute : ValidationAttribute
    {
        private readonly int _length;
        private readonly string _fieldName;

        public ArrayLengthAttribute(int length, string fieldName)
        {
            _length = length;
            _fieldName = fieldName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is Array array)
            {
                if (array.Length == _length)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"Список {_fieldName} мусить містити {_length} значень!");
                }
            }

            return new ValidationResult($"Список {_fieldName} мусить бути типу Array");
        }
    }
}
