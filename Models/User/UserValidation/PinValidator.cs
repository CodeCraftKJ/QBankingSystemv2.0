using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.User.UserValidation
{
    public class PinValidator : AbstractValidator<string>
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

        public PinValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("PIN cannot be empty.")
                .Matches(@"^\d{4}$").WithMessage("Invalid PIN format. PIN must contain 4 digits.");
        }

    }
}
