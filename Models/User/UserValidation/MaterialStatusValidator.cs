using FluentValidation;
using FluentValidation.Results;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.User.UserValidation
{
    public class MaterialStatusValidator : AbstractValidator<string>
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

        public MaterialStatusValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Material status cannot be empty.")
                .Must(BeAValidMaterialStatus).WithMessage("Invalid material status. Available options: Single, Married, Divorced, Widowed, Other");
        }

        private bool BeAValidMaterialStatus(string status)
        {
            string pattern = @"^(Single|Married|Divorced|Widowed|Other)$";
            return Regex.IsMatch(status, pattern);
        }

    }
}