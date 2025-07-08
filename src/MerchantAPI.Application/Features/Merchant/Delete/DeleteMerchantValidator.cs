using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MerchantAPI.Application.Features.Merchant.Delete
{
    public class DeleteMerchantValidator : AbstractValidator<DeleteMerchant>
    {
        public DeleteMerchantValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id is required");
        }
    }
  
}
