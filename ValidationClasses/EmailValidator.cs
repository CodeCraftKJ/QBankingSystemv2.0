using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class EmailValidator : AbstractValidator<string>
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

        public EmailValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email address format.");
                // Dodaj więcej reguł walidacji według potrzeb
        }
    }
}
