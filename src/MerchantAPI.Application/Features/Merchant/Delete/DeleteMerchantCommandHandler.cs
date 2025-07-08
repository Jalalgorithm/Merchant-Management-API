using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MerchantAPI.Application.Commons.Data;
using MerchantAPI.Application.Commons.Responses;

namespace MerchantAPI.Application.Features.Merchant.Delete
{
    public class DeleteMerchantCommandHandler(IApplicationDbContext dbContext) : IRequestHandler<DeleteMerchantCommand, ServiceResponse<int>>
    {
        public async Task<ServiceResponse<int>> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
        {

            var merchant = await dbContext.Merchants.FindAsync(request.deleteMerchant.Id , cancellationToken);

            if (merchant == null)
            {
                return ServiceResponse<int>.Failure("Merchant not found.");
            }

            dbContext.Merchants.Remove(merchant);
            await dbContext.SaveChangesAsync(cancellationToken);
            return ServiceResponse<int>.Success(merchant.Id, "Merchant deleted successfully.");

        }
    }
}
