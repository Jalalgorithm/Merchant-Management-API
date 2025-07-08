using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MerchantAPI.Application.Commons.Responses;

namespace MerchantAPI.Application.Features.Merchant.Delete
{
    public record DeleteMerchantCommand(DeleteMerchant deleteMerchant ) : IRequest<ServiceResponse<int>>; 
}
