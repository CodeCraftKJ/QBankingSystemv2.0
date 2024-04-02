using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class UsernameValidator : AbstractValidator<string>
    {
        public ValidationResult ValidateUsername(string username)
        {
            var validator = new UsernameValidator();
            return validator.Validate(username);
        }

        public ValidationResult ValidateAndShowMessage(TextBox textBox)
        {
            string username = textBox.Text;
            var result = ValidateUsername(username);
            if (!result.IsValid)
            {
                MessageBox.Show(result.Errors[0].ErrorMessage);
            }
            return result;
        }

        public UsernameValidator()
        {
            RuleFor(username => username)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .MinimumLength(4).WithMessage("Username must be at least 4 characters long.")
                .MaximumLength(20).WithMessage("Username cannot exceed 20 characters.");
        }
    }
}
