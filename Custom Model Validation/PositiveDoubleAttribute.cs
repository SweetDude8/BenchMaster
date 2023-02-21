using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SmolovJrBench.Custom_Model_Validation
{
    public class PositiveDoubleAttribute : ValidationAttribute
    {
        public PositiveDoubleAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            value = value.ToString().Replace(',', '.');

            if (double.TryParse(value.ToString(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double result))
            {
                return result > 0;
            }

            return false;
        }
    }
}
