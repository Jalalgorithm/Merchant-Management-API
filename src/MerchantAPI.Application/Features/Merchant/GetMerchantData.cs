using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantAPI.Application.Features.Merchant
{
    public record GetMerchantData : MerchantBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
    }
}
