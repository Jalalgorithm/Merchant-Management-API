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

namespace MerchantAPI.Application.Features.Merchant.GetAll
{
    public record GetAllMerchantQueryHandler(IMapper mapper , IApplicationDbContext dbContext) : IRequestHandler<GetAllMerchantQuery, ServiceResponse<IEnumerable<GetAllMerchant>>>
    {
        public async Task<ServiceResponse<IEnumerable<GetAllMerchant>>> Handle(GetAllMerchantQuery request, CancellationToken cancellationToken)
        {
            var merchants = await dbContext.Merchants.AsNoTracking().ToListAsync(cancellationToken);

            return merchants.Count > 0
                ? ServiceResponse<IEnumerable<GetAllMerchant>>.Success(mapper.Map<IEnumerable<GetAllMerchant>>(merchants), "Merchants retrieved successfully")
                : ServiceResponse<IEnumerable<GetAllMerchant>>.Success([] ,"Null");
        }
    }
}
