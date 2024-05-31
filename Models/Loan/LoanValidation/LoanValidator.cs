using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.Models.Loan.Loan
{
    public class LoanValidator : AbstractValidator<LoanInput>
    {
        private static ToolTip toolTip = new ToolTip();

        public ValidationResult ValidateAndShowMessage(TextBox textBox, LoanInput loanInput)
        {
            var result = Validate(loanInput);
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

        public LoanValidator()
        {
            RuleFor(loan => loan.ToAccount)
                .NotEmpty().WithMessage("Destination account cannot be empty.");
            RuleFor(loan => loan.LoanAmount)
                .GreaterThan(0).WithMessage("Loan amount must be greater than zero.");
            RuleFor(loan => loan.LoanInterestRate)
                .InclusiveBetween(0, 100).WithMessage("Interest rate must be between 0 and 100.");
            RuleFor(loan => loan.Currency)
                .NotEmpty().WithMessage("Currency cannot be empty.")
                .Length(3).WithMessage("Currency must be a 3-letter code.");
        }
    }

    public class LoanInput
    {
        public string ToAccount { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal LoanInterestRate { get; set; }
        public string Currency { get; set; }
    }
}
