using FluentValidation.Results;
using QBankingSystemv2._0.ValidationClasses;
using System.Collections.Generic;

namespace QBankingSystemv2._0
{
    public static partial class RegistrationManager
    {
        private static bool IsValid()
        {
            var validationResults = new List<ValidationResult>();
            validationResults.Add(new PinValidator().ValidateAndShowMessage(_textPIN));
            validationResults.Add(new PeselValidator().ValidateAndShowMessage(_textPesel));
            validationResults.Add(new PhoneValidator().ValidateAndShowMessage(_textPhone));
            validationResults.Add(new LastnameValidator().ValidateAndShowMessage(_textLastName));
            validationResults.Add(new FirstnameValidator().ValidateAndShowMessage(_textFirstName));
            validationResults.Add(new UsernameValidator().ValidateAndShowMessage(_textUserName));
            validationResults.Add(new RepeatPasswordValidator().ValidateAndShowMessage(_textBoxPassword, _textRepeatPassword));
            validationResults.Add(new PasswordValidator().ValidateAndShowMessage(_textBoxPassword));
            validationResults.Add(new MaterialStatusValidator().ValidateAndShowMessage(_textMatrialStatus));
            validationResults.Add(new AddressValidator().ValidateAndShowMessage(_textAddress));
            validationResults.Add(new DateOfBirthValidator().ValidateAndShowMessage(_textBirth));
            validationResults.Add(new EmailValidator().ValidateAndShowMessage(_textEmail));

            foreach (var result in validationResults)
            {
                if (!result.IsValid)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

