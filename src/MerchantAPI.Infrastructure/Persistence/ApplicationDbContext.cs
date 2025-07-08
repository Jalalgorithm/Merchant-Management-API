using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantAPI.Application.Commons.Data;
using MerchantAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MerchantAPI.Infrastructure.Persistence
{
    public class ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : DbContext(options) , IApplicationDbContext
    {
        public DbSet<Merchant> Merchants=> Set<Merchant>();
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => base.SaveChangesAsync(cancellationToken);
        protected override void OnModelCreating(ModelBuilder modelBuilder)=> modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    }
   
}
