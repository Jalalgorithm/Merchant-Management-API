using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantAPI.Domain.Entities;
using MerchantAPI.Domain.ValueObjects;

namespace MerchantAPI.Infrastructure.Persistence
{
    public static class ApplicationDbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if(!context.Merchants.Any())
            {
                var merchants = new List<Merchant>
                {
                    new() { BusinessName = "Jade Ventures", Email = "jade@example.com", PhoneNumber = "08012345678", Country = "Nigeria", Status = Status.Active },
                new() { BusinessName = "Kigali Textiles", Email = "kigali@rwanda.com", PhoneNumber = "+250789000001", Country = "Rwanda", Status = Status.Pending },
                new() { BusinessName = "Cape Gold", Email = "capegold@sa.co.za", PhoneNumber = "+27 710123456", Country = "South Africa", Status = Status.Active },
                new() { BusinessName = "Nairobi Prints", Email = "nairobi@prints.ke", PhoneNumber = "+254712345678", Country = "Kenya", Status = Status.Active },
                new() { BusinessName = "Accra Deals", Email = "accradeals@gh.com", PhoneNumber = "+233 501234567", Country = "Ghana", Status = Status.Pending },
                new() { BusinessName = "Lagos Bistro", Email = "bistro@lagos.ng", PhoneNumber = "08098765432", Country = "Nigeria", Status = Status.Inactive },
                new() { BusinessName = "Marrakech Rugs", Email = "marrakechrugs@ma.com", PhoneNumber = "+212 658123456", Country = "Morocco", Status = Status.Active },
                new() { BusinessName = "Kinshasa Styles", Email = "kinshasa@style.cd", PhoneNumber = "+243890001122", Country = "DR Congo", Status = Status.Active },
                new() { BusinessName = "Tunis Tech", Email = "tunistech@tn.com", PhoneNumber = "+21699112233", Country = "Tunisia", Status = Status.Inactive },
                new() { BusinessName = "Cairo Bazaar", Email = "bazaar@cairo.eg", PhoneNumber = "+20 1011234567", Country = "Egypt", Status = Status.Pending },
                new() { BusinessName = "Ibadan Outfitters", Email = "ibadanfit@ng.com", PhoneNumber = "08111222333", Country = "Nigeria", Status = Status.Active },
                new() { BusinessName = "Johannesburg Wears", Email = "wears@joburg.co.za", PhoneNumber = "+27 721234567", Country = "South Africa", Status = Status.Pending },
                };

                context.Merchants.AddRange(merchants);
                await context.SaveChangesAsync();
            }
        }
    }
}
