using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MerchantAPI.Domain.ValueObjects;

namespace MerchantAPI.Application.Features.Merchant.Create
{
    public class CreateMerchantValidator : AbstractValidator<CreateMerchant>
    {
        public CreateMerchantValidator() 
        {
            RuleFor(x => x.BusinessName)
                .NotEmpty().WithMessage("Business name is required.")
                .Length(5,100).WithMessage("Merchant name must be between 5 and 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => Enum.GetNames(typeof(Status)).Contains(status))
                .WithMessage("Invalid status value. It must be either Pending, Active, or Inactive.");
        }
    }
}
