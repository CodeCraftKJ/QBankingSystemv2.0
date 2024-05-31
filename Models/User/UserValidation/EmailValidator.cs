using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.User.UserValidation
{
    public class EmailValidator : AbstractValidator<string>
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

        public EmailValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .Must(BeValidEmailFormat).WithMessage("Invalid email address format. Proper Format: example@example.com");
        }

        private bool BeValidEmailFormat(string email)
        {
            string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            return Regex.IsMatch(email, pattern);
        }

    }
}
