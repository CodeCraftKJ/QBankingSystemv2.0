using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.Account.Account
{
    public class WithdrawalLimitValidator : AbstractValidator<decimal>
    {
        private static readonly ToolTip toolTip = new ToolTip();
        private const decimal MinWithdrawalLimit = 10;
        private const decimal MaxWithdrawalLimit = 10000;

        public ValidationResult ValidateAndShowMessage(TextBox textBox)
        {
            decimal value;
            bool parseSuccess = decimal.TryParse(textBox.Text, out value);
            if (!parseSuccess)
            {
                toolTip.Show("Invalid withdrawal limit format. Please enter a valid decimal number.", textBox, textBox.Width, 0);
                return new ValidationResult(new[] { new ValidationFailure("WithdrawalLimit", "Invalid withdrawal limit format.") });
            }
            else if (value < MinWithdrawalLimit || value > MaxWithdrawalLimit)
            {
                toolTip.Show($"Withdrawal limit must be between {MinWithdrawalLimit} and {MaxWithdrawalLimit}.", textBox, textBox.Width, 0);
                return new ValidationResult(new[] { new ValidationFailure("WithdrawalLimit", $"Withdrawal limit must be between {MinWithdrawalLimit} and {MaxWithdrawalLimit}.") });
            }
            else
            {
                toolTip.Hide(textBox);
                return new ValidationResult();
            }
        }
    }
}
