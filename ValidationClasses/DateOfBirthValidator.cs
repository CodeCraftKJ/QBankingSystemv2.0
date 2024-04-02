using FluentValidation;
using FluentValidation.Results;
using System;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class DateOfBirthValidator : AbstractValidator<DateTime>
    {
        public ValidationResult ValidateAndShowMessage(TextBox textBox)
        {
            string dateText = textBox.Text;
            if (!DateTime.TryParse(dateText, out DateTime date))
            {
                MessageBox.Show("Invalid date format.");
                return new ValidationResult(new[] { new ValidationFailure("", "Invalid date format.") });
            }

            var result = Validate(date);
            if (!result.IsValid)
            {
                MessageBox.Show(result.Errors[0].ErrorMessage);
            }
            return result;
        }

        public DateOfBirthValidator()
        {
            RuleFor(date => date)
                .NotEmpty().WithMessage("Date of birth cannot be empty.");
            // Dodaj więcej reguł walidacji według potrzeb
        }
    }
}
