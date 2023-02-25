using System.Globalization;
using System.Windows.Controls;

namespace Chemsoft.Core.Rules
{
    internal class MinimumCharactersRule : ValidationRule
    {
        public uint MinimumCharacters { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if (str?.Length < MinimumCharacters)
            {
                return new ValidationResult(false, $"Min length must be grater than {MinimumCharacters}");
            }

            return new ValidationResult(true, null);
        }
    }
}
