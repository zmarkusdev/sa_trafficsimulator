using System.Globalization;
using System.Windows.Controls;

namespace RuleEngineUserInterface.Technics.ValidationRules
{

    /// <summary>
    /// Validates that a input is an integer between 4 and 59
    /// </summary>
    public class IntegerValidationRule : ValidationRule
    {

        /// <summary>
        /// Validate if the input is a integer
        /// </summary>
        /// <param name="value">input from the UI</param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string val = (value ?? "").ToString();

                int intval = 0;

                // Try to convert the string to an integer
                if (int.TryParse(val, out intval))
                {
                    // Check the input if it is an integer
                    if (intval <= 3)
                    {
                        return new ValidationResult(false, "time must be > 3");
                    }
                    else if (intval >= 60)
                    {
                        return new ValidationResult(false, "time must be < 60");
                    }

                    // At this point the result is valid
                    return ValidationResult.ValidResult;
                }
                else
                {
                    return new ValidationResult(false, "not a integer");
                }
            }
            catch
            {
                return new ValidationResult(false, "enter a integer");
            }
        }
    }
}
