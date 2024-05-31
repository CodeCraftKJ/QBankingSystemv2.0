using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.Account.Account
{
    public class AccountNameValidator : AbstractValidator<string>
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

        public AccountNameValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Account name cannot be empty.")
                .MinimumLength(3).WithMessage("Account name must be at least 3 characters long.");
        }
    }
}
