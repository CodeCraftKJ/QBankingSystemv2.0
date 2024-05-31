using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.Transfer.Transfer
{
    public class AmountValidator : AbstractValidator<string>
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

        public AmountValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Amount cannot be empty.")
                .Must(BeValidPositiveDecimal).WithMessage("Invalid amount. Please enter a valid positive decimal number.");
        }

        private bool BeValidPositiveDecimal(string amount)
        {
            decimal value;
            return decimal.TryParse(amount, out value) && value >= 0;
        }
    }
}
