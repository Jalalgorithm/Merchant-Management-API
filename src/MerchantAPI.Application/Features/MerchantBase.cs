using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantAPI.Application.Features
{
    public abstract record MerchantBase
    {
        public string BusinessName { get; init; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }

    }
}
