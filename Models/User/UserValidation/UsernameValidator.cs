using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.User.UserValidation
{
    public class UsernameValidator : AbstractValidator<string>
    {
        private static ToolTip toolTip = new ToolTip();

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
                toolTip.Show(result.Errors[0].ErrorMessage, textBox, textBox.Width, 0);
            }
            else
            {
                toolTip.Hide(textBox);
            }
            return result;
        }
        public UsernameValidator()
        {
            RuleFor(username => username)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .Matches(@"^[a-zA-Z0-9_]+$").WithMessage("Username can only contain letters, numbers, and underscores.")
                .MinimumLength(4).WithMessage("Username must be at least 4 characters long.")
                .MaximumLength(20).WithMessage("Username cannot exceed 20 characters.");
        }

    }
}
