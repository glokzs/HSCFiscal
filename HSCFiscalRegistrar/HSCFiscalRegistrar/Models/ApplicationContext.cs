using HSCFiscalRegistrar.Models.APKInfo;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HSCFiscalRegistrar.Models
{
    public sealed class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Kkm> Kkms { get; set; }
        public DbSet<Org> Orgs { get; set; }
        public DbSet<RegInfo> RegInfos { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Request> Requests { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}