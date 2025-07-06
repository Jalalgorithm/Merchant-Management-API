using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MerchantAPI.Application.Commons.Responses;

namespace MerchantAPI.Application.Features.Merchant.Get
{
    public class GetMerchantQueryHandler : IRequestHandler<GetMerchantQuery, ServiceResponse<GetMerchant>>
    {
        public Task<ServiceResponse<GetMerchant>> Handle(GetMerchantQuery request, CancellationToken cancellationToken)
        {
            // Implementation of the query handler logic goes here
            throw new NotImplementedException();
        }
    }

}
