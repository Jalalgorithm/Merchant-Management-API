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
using MerchantAPI.Domain.Entities;




namespace MerchantAPI.Application.Features.Merchant.Create
{
    public class CreateMerchantCommandHandler(ICountryValidatorService countryValidator , IApplicationDbContext dbContext , IMapper mapper) : IRequestHandler<CreateMerchantCommand, ServiceResponse<GetMerchantData>>
    {

        public async Task<ServiceResponse<GetMerchantData>> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
        {
            var isValidCountry = await countryValidator.IsValidCountryAsync(request.CreateMerchant.Country);
            if (!isValidCountry)
            {
                return ServiceResponse<GetMerchantData>.Failure("Invalid country provided.");
            }

            var mapDto = mapper.Map<Domain.Entities.Merchant>(request.CreateMerchant);
            if(mapDto == null)
            {
                return ServiceResponse<GetMerchantData>.Failure("Invalid request");
            }

            dbContext.Merchants.Add(mapDto);
            await dbContext.SaveChangesAsync(cancellationToken);

            return ServiceResponse<GetMerchantData>.Success(mapper.Map<GetMerchantData>(mapDto), "Merchant created successfully.");
        }

       
    }
}

