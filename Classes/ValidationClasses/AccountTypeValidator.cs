using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class AccountTypeValidator : AbstractValidator<string>
    {
        private static ToolTip toolTip = new ToolTip();

        public ValidationResult ValidateAndShowMessage(ComboBox comboBox)
        {
            string value = comboBox.SelectedItem?.ToString();
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

        public AccountTypeValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Please select an account type.");
        }
    }
}
