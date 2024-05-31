using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.Account.Account
{
    public class CurrencyValidator : AbstractValidator<string>
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

        public CurrencyValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Please select a currency.")
                .Must(BeValidCurrency).WithMessage("Invalid currency. Only USD, EURO, or PLN are allowed.");
        }

        private bool BeValidCurrency(string currency)
        {
            return currency == "USD" || currency == "EURO" || currency == "PLN";
        }
    }
}