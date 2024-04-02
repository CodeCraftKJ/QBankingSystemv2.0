using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class RepeatPasswordValidator : AbstractValidator<string>
    {
        public ValidationResult ValidateAndShowMessage(TextBox passwordTextBox, TextBox repeatPasswordTextBox)
        {
            string password = passwordTextBox.Text;
            string repeatPassword = repeatPasswordTextBox.Text;
            
            var result = Validate(repeatPassword);
            if (!result.IsValid)
            {
                MessageBox.Show(result.Errors[0].ErrorMessage);
            }
            else if (password != repeatPassword)
            {
                MessageBox.Show("Passwords do not match.");
                result.Errors.Clear();
                result.Errors.Add(new ValidationFailure("", "Passwords do not match."));
            }

            return result;
        }

        public RepeatPasswordValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Repeat password cannot be empty.");
                // Dodaj więcej reguł walidacji według potrzeb
        }
    }
}
