using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class AddressValidator : AbstractValidator<string>
    {
        public ValidationResult ValidateAndShowMessage(TextBox textBox)
        {
            string value = textBox.Text;
            var result = Validate(value);
            if (!result.IsValid)
            {
                MessageBox.Show(result.Errors[0].ErrorMessage);
            }
            return result;
        }

        public AddressValidator()
        {
            RuleFor(value => value)
                .NotEmpty().WithMessage("Address cannot be empty.");
                // Dodaj więcej reguł walidacji według potrzeb
        }
    }
}
