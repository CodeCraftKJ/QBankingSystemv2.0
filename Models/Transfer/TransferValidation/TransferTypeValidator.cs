using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.Transfer.Transfer
{
    public class TransferTypeValidator : AbstractValidator<string>
    {
        private static readonly ToolTip toolTip = new();

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

        public TransferTypeValidator()
        {
            RuleFor(value => value)
                .Must(value => value == "Internal Transfer" || value == "External Transfer")
                .WithMessage("Please select either Internal Transfer or External Transfer.");
        }

    }
}
