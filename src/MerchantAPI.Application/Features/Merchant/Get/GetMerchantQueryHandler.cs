using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MerchantAPI.Application.Commons.Data;
using MerchantAPI.Application.Commons.Responses;
using Microsoft.EntityFrameworkCore;

namespace MerchantAPI.Application.Features.Merchant.Get
{
    public class GetMerchantQueryHandler(IMapper mapper , IApplicationDbContext dbContext) : IRequestHandler<GetMerchantQuery, ServiceResponse<GetMerchant>>
    {
        public async Task<ServiceResponse<GetMerchant>> Handle(GetMerchantQuery request, CancellationToken cancellationToken)
        {
            var merchant = await dbContext.Merchants.FirstOrDefaultAsync(x=>x.Id == request.id, cancellationToken);

            if (merchant == null)
            {
                return ServiceResponse<GetMerchant>.Failure("Merchant not found");
            }

            var merchantResponse = mapper.Map<GetMerchant>(merchant);
            return ServiceResponse<GetMerchant>.Success(merchantResponse, "Merchant retrieved successfully");
        }
    }

}
