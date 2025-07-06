using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MerchantAPI.Application.Commons.Responses;

namespace MerchantAPI.Application.Features.Merchant.GetAll
{
    public record GetAllMerchantQueryHandler : IRequestHandler<GetAllMerchantQuery, ServiceResponse<List<GetAllMerchant>>>
    {
        public Task<ServiceResponse<List<GetAllMerchant>>> Handle(GetAllMerchantQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
