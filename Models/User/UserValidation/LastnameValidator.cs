using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.User.UserValidation
{
    public class LastnameValidator : AbstractValidator<string>
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

        public LastnameValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Lastname cannot be empty.")
                .Matches(@"^[A-ZŻŹĆĄŚĘŁÓŃ][a-zżźćńółęąś]+$")
                .WithMessage("Invalid lastname format. Lastname should start with a capital letter and consist of lowercase letters.");
        }

    }
}