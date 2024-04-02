using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    internal class FirstnameValidator : AbstractValidator<string>
    {
        public ValidationResult ValidateAndShowMessage(TextBox textBox)
        {
            string value = textBox.Text;
            var validator = new FirstnameValidator();
            var result = validator.Validate(value);
            if (!result.IsValid)
            {
                MessageBox.Show(result.Errors[0].ErrorMessage);
            }
            return result;
        }

        public FirstnameValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Firstname cannot be empty.");
                // Dodaj więcej reguł walidacji według potrzeb
        }
    }
}
