using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class AddressValidator : AbstractValidator<string>
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

        public AddressValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Address cannot be empty.")
                .Matches(@"^[A-ZŻŹĆĄŚĘŁÓŃ][a-zżźćńółęąś]+")
                .WithMessage("Proper Format: [City] [Street] [Number]. City name should start with a capital letter and consist of lowercase letters.")
                .Matches(@"\s[A-ZŻŹĆĄŚĘŁÓŃ][a-zżźćńółęąś]+")
                .WithMessage("Proper Format: [City] [Street] [Number]. Street name should start with a capital letter and consist of lowercase letters.")
                .Matches(@"\s\d{1,4}$")
                .WithMessage("Proper Format: [City] [Street] [Number]. House number should consist of 1 to 4 digits.");
        }

    }
}
