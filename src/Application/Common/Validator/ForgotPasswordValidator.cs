using Excallibur.Application.Common.Models.RequestModel;
using FluentValidation;
using System.Text.RegularExpressions;
namespace Excallibur.Application.Common.Validator
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordRequestModel>
    {
        public ForgotPasswordValidator()
        {
            RuleFor(x => x.Email.Trim().ToLower())
                .NotNull().NotEmpty().WithMessage("Enter your email address.")
                .MaximumLength(100).WithMessage("Email cannot be longer than 100 words")
                .Must(email => ValidEmail(email)).WithMessage("Invalid email format.");

        }

        public static bool ValidEmail(string email)
        {
            const string emailRegex =
                @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            return new Regex(emailRegex).IsMatch(email);
        }

    }
}
