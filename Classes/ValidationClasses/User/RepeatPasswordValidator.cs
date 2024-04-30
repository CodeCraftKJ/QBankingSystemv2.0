using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class RepeatPasswordValidator : AbstractValidator<string>
    {
        private static ToolTip toolTip = new ToolTip();

        public ValidationResult ValidateAndShowMessage(TextBox passwordTextBox, TextBox repeatPasswordTextBox)
        {
            string password = passwordTextBox.Text;
            string repeatPassword = repeatPasswordTextBox.Text;

            var result = Validate(repeatPassword);
            if (!result.IsValid)
            {
                toolTip.Show(result.Errors[0].ErrorMessage, repeatPasswordTextBox, repeatPasswordTextBox.Width, 0);
            }
            else if (password != repeatPassword)
            {
                toolTip.Show("Passwords do not match.", repeatPasswordTextBox, repeatPasswordTextBox.Width, 0);
                result.Errors.Clear();
                result.Errors.Add(new ValidationFailure("", "Passwords do not match."));
            }
            else
            {
                toolTip.Hide(repeatPasswordTextBox);
            }

            return result;
        }

        public RepeatPasswordValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Repeat password cannot be empty.");
        }

    }
}
