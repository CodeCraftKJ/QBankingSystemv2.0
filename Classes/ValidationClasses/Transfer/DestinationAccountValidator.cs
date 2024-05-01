using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class DestinationAccountValidator : AbstractValidator<string>
    {
        private static ToolTip toolTip = new ToolTip();

        public ValidationResult ValidateAndShowMessage(TextBox comboBox)
        {
            string value = comboBox.Text;
            var result = Validate(value);
            if (!result.IsValid)
            {
                toolTip.Show(result.Errors[0].ErrorMessage, comboBox, comboBox.Width, 0);
            }
            else
            {
                toolTip.Hide(comboBox);
            }
            return result;
        }

        public DestinationAccountValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Please select a destination account.")
                .Matches(@"^\d{9}$").WithMessage("Destination account must be a 9-digit number.");
        }
    }
}
