using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class PasswordValidator : AbstractValidator<string>
    {
        private static ToolTip toolTip = new ToolTip();

        public ValidationResult ValidateAndShowMessage(TextBox textBox)
        {
            string value = textBox.Text;
            var result = Validate(value);
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

        public PasswordValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$")
                .WithMessage("Invalid password format. Password must contain at least one uppercase letter, one lowercase letter, and one digit.");
        }

    }
}