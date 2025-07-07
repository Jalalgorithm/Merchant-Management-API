using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MerchantAPI.Application.Commons.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Merchant> Merchants { get;}
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
