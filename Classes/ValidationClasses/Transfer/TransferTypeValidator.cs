﻿using FluentValidation;
using FluentValidation.Results;
using System.Windows.Forms;

namespace QBankingSystemv2._0.ValidationClasses
{
    public class TransferTypeValidator : AbstractValidator<string>
    {
        private static ToolTip toolTip = new ToolTip();

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
                .NotEmpty().WithMessage("Please select a transfer type.");
        }
    }
}
