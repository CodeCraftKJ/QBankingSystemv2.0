using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.Account.Account
{
    public class TransferLimitValidator : AbstractValidator<decimal>
    {
        private static readonly ToolTip toolTip = new ToolTip();
        private const decimal MinTransferLimit = 10;
        private const decimal MaxTransferLimit = 10000;

        public ValidationResult ValidateAndShowMessage(TextBox textBox)
        {
            decimal value;
            bool parseSuccess = decimal.TryParse(textBox.Text, out value);
            if (!parseSuccess)
            {
                toolTip.Show("Invalid transfer limit format. Please enter a valid decimal number.", textBox, textBox.Width, 0);
                return new ValidationResult(new[] { new ValidationFailure("TransferLimit", "Invalid transfer limit format.") });
            }
            else if (value < MinTransferLimit || value > MaxTransferLimit)
            {
                toolTip.Show($"Transfer limit must be between {MinTransferLimit} and {MaxTransferLimit}.", textBox, textBox.Width, 0);
                return new ValidationResult(new[] { new ValidationFailure("TransferLimit", $"Transfer limit must be between {MinTransferLimit} and {MaxTransferLimit}.") });
            }
            else
            {
                toolTip.Hide(textBox);
                return new ValidationResult();
            }
        }
    }
}
