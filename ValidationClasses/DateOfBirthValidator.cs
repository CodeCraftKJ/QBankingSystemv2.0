using FluentValidation;
using FluentValidation.Results;
using System;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class DateOfBirthValidator : AbstractValidator<DateTime>
    {
        private static ToolTip toolTip = new ToolTip();

        public ValidationResult ValidateAndShowMessage(TextBox textBox)
        {
            string dateText = textBox.Text;
            if (!DateTime.TryParse(dateText, out DateTime date))
            {
                toolTip.Show("Invalid date format.", textBox, textBox.Width, 0);
                return new ValidationResult(new[] { new ValidationFailure("", "Invalid date format.") });
            }

            var result = Validate(date);
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

        private bool BeValidDateFormat(DateTime date)
        {
            return DateTime.TryParse(date.ToString("dd.MM.yyyy"), out _);
        }

    }
}