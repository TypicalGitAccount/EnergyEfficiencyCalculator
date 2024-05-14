using System.ComponentModel.DataAnnotations;

namespace EnergyEfficiencyBE.Models.Validation
{
    public class SpecificValuesFromConstantsAttribute : ValidationAttribute
    {
        private string[] _structTypeNames;

        public SpecificValuesFromConstantsAttribute(string[] structTypeNames)
        {
            _structTypeNames = structTypeNames;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            for (int i = 0; i < _structTypeNames.Length; i++)
            {
                var structType = Type.GetType(_structTypeNames[i]);
                if (structType == null)
                {
                    return new ValidationResult($"Struct type '{_structTypeNames[i]}' not found.");
                }

                var properties = structType.GetNestedTypes().Select(t => t.GetFields().Select(p => p.GetValue(null))).SelectMany(x => x);
                properties = properties.Concat(structType.GetFields().Select(t => t.GetValue(null)));

                if (properties.Contains(value))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult($"Shkrek yebaniy a ne kod {string.Join(", ", _structTypeNames)}");
        }
    }
}
