using FluentValidation;
using FluentValidation.Results;
using System;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class DateOfBirthValidator : AbstractValidator<string>
    {
        private static ToolTip toolTip = new ToolTip();

        public ValidationResult ValidateAndShowMessage(TextBox textBox)
        {
            string dateText = textBox.Text;
            var result = Validate(dateText);
            if (!result.IsValid)
            {
                toolTip.Show(result.Errors[0].ErrorMessage, textBox, textBox.Width, 0);
            }
            else
            {
                toolTip.Hide(textBox);
            }
            return result;
        }

        public DateOfBirthValidator()
        {
            RuleFor(date => date)
                .NotEmpty().WithMessage("Date of birth cannot be empty.")
                .Must(BeValidDateFormat).WithMessage("Invalid date format. Proper Format: [DD.MM.RRRR]");
        }

        private bool BeValidDateFormat(string dateText)
        {
            string[] formats = { "dd.MM.yyyy" };
            return DateTime.TryParseExact(dateText, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _);
        }
    }
}
