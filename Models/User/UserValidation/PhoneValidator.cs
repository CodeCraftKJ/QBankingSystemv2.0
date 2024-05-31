using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.User.UserValidation
{
    public class PhoneValidator : AbstractValidator<string>
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

        public PhoneValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Phone cannot be empty.")
                .Matches(@"^\d{9,10}$").WithMessage("Invalid phone number format. Phone number must contain 9 or 10 digits.");
        }

    }
}
