using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class PasswordValidator : AbstractValidator<string>
    {
        public ValidationResult ValidateAndShowMessage(TextBox textBox)
        {
            string value = textBox.Text;
            var result = Validate(value);
            if (!result.IsValid)
            {
                MessageBox.Show(result.Errors[0].ErrorMessage);
            }
            return result;
        }

        public PasswordValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");
                // Dodaj więcej reguł walidacji według potrzeb
        }
    }
}
