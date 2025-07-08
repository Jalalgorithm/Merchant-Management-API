using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MerchantAPI.Application.Commons.Data;
using MerchantAPI.Application.Commons.Responses;
using MerchantAPI.Infrastructure.Services.CountryValidator;

namespace MerchantAPI.Application.Features.Merchant.Update
{
    public class UpdateMerchantCommandHandler(IApplicationDbContext dbContext , IMapper mapper , ICountryValidatorService countryValidator) : IRequestHandler<UpdateMerchantCommand, ServiceResponse<int>>
    {
        public async Task<ServiceResponse<int>> Handle(UpdateMerchantCommand request, CancellationToken cancellationToken)
        {
            if(request.Id <= 0)
            {
                return ServiceResponse<int>.Failure("Id is required.");
            }

            var isValidCountry = await countryValidator.IsValidCountryAsync(request.updateMerchant.Country);
            if (!isValidCountry)
            {
                return ServiceResponse<int>.Failure("Invalid country provided.");
            }

            var existingMerchant = await dbContext.Merchants.FindAsync(request.Id);
            if (existingMerchant == null)
            {
                return ServiceResponse<int>.Failure("Merchant not found.");
            }

            var mapDto = mapper.Map(request.updateMerchant , existingMerchant);

            if(mapDto == null)
            {
                return ServiceResponse<int>.Failure("Invalid request");
            }

            dbContext.Merchants.Update(mapDto);
            await dbContext.SaveChangesAsync(cancellationToken);
            return ServiceResponse<int>.Success(mapDto.Id, "Merchant updated successfully");
        }
    }
}
