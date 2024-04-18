using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class PeselValidator : AbstractValidator<string>
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

        public PeselValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("PESEL cannot be empty.")
                .Matches(@"^\d{11}$").WithMessage("Invalid PESEL format. PESEL must contain exactly 11 digits.");
        }

    }
}
