using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Fiscal.Data
{
    public class AppDataFiscalContext : IdentityDbContext<User>
    {
        public DbSet<Kkm> Kkms { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<ShiftOperation> ShiftOperations { get; set; }
        
        public AppDataFiscalContext(DbContextOptions<AppDataFiscalContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseLazyLoadingProxies();
    }
}