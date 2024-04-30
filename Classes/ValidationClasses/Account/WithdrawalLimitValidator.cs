using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class WithdrawalLimitValidator : AbstractValidator<decimal>
    {
        private static ToolTip toolTip = new ToolTip();

        public ValidationResult ValidateAndShowMessage(TextBox textBox)
        {
            decimal value;
            bool parseSuccess = decimal.TryParse(textBox.Text, out value);
            if (!parseSuccess)
            {
                toolTip.Show("Invalid withdrawal limit format. Please enter a valid decimal number.", textBox, textBox.Width, 0);
                return new ValidationResult(new[] { new ValidationFailure("WithdrawalLimit", "Invalid withdrawal limit format.") });
            }
            else if (value < 10 || value > 10000)
            {
                toolTip.Show("Withdrawal limit must be between 10 and 10000.", textBox, textBox.Width, 0);
                return new ValidationResult(new[] { new ValidationFailure("WithdrawalLimit", "Withdrawal limit must be between 10 and 10000.") });
            }
            else
            {
                toolTip.Hide(textBox);
                return new ValidationResult();
            }
        }
    }
}
