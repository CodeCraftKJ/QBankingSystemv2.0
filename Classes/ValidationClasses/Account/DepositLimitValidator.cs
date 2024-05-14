using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class DepositLimitValidator : AbstractValidator<decimal>
    {
        private static readonly ToolTip toolTip = new ToolTip();
        private const decimal MinDepositLimit = 10;
        private const decimal MaxDepositLimit = 10000;

        public ValidationResult ValidateAndShowMessage(TextBox textBox)
        {
            decimal value;
            bool parseSuccess = decimal.TryParse(textBox.Text, out value);
            if (!parseSuccess)
            {
                toolTip.Show("Invalid deposit limit format. Please enter a valid decimal number.", textBox, textBox.Width, 0);
                return new ValidationResult(new[] { new ValidationFailure("DepositLimit", "Invalid deposit limit format.") });
            }
            else if (value < MinDepositLimit || value > MaxDepositLimit)
            {
                toolTip.Show($"Deposit limit must be between {MinDepositLimit} and {MaxDepositLimit}.", textBox, textBox.Width, 0);
                return new ValidationResult(new[] { new ValidationFailure("DepositLimit", $"Deposit limit must be between {MinDepositLimit} and {MaxDepositLimit}.") });
            }
            else
            {
                toolTip.Hide(textBox);
                return new ValidationResult();
            }
        }
    }
}
