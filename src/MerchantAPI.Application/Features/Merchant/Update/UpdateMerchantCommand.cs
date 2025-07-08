using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MerchantAPI.Application.Commons.Responses;

namespace MerchantAPI.Application.Features.Merchant.Update
{
    public record UpdateMerchantCommand(int Id , UpdateMerchant updateMerchant) : IRequest<ServiceResponse<int>>;
}
