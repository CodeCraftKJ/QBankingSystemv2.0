using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.Account.Account
{
    public class InitialBalanceValidator : AbstractValidator<decimal>
    {
        private static ToolTip toolTip = new ToolTip();

        public ValidationResult ValidateAndShowMessage(TextBox textBox)
        {
            decimal value;
            bool parseSuccess = decimal.TryParse(textBox.Text, out value);
            if (!parseSuccess)
            {
                toolTip.Show("Invalid initial balance format. Please enter a valid decimal number.", textBox, textBox.Width, 0);
                return new ValidationResult(new[] { new ValidationFailure("InitialBalance", "Invalid initial balance format.") });
            }
            else
            {
                toolTip.Hide(textBox);
                return new ValidationResult();
            }
        }

        public InitialBalanceValidator()
        {
            RuleFor(value => value)
                .GreaterThan(0).WithMessage("Initial balance must be greater than 0.");
        }
    }
}
