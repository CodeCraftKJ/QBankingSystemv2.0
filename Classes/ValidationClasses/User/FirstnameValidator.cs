using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class FirstnameValidator : AbstractValidator<string>
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

        public FirstnameValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Firstname cannot be empty.")
                .Matches(@"^[A-ZŻŹĆĄŚĘŁÓŃ][a-zżźćńółęąś]+$")
                .WithMessage("Invalid firstname format. Firstname should start with a capital letter and consist of lowercase letters.");
        }

    }
}