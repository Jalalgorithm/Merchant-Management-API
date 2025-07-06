using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MerchantAPI.Application.Commons.Responses;

namespace MerchantAPI.Application.Features.Merchant.Create
{
    public class CreateMerchantCommandHandler : IRequestHandler<CreateMerchantCommand, ServiceResponse<int>>
    {

        public Task<ServiceResponse<int>> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

