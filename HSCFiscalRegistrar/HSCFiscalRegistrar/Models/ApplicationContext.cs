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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);   
            builder.Entity<Kkm>().HasData(new Kkm()
            {
                Id = "2",
                SerialNumber = "12345678",
                PointOfPayment = "",
                FnsKkmId = "123123123123",
                TerminalNumber = ""  
            });
            builder.Entity<Org>().HasData(new Org()
            {
                Id = "3",
                Okved = "",
                TaxationType = 0,
                Inn = "160840027676",
                Title = "Bill"
            });
            builder.Entity<RegInfo>().HasData(new RegInfo()
            {
                Id = "1",
                KkmId = "2",
                OrgId = "3"
            });
            builder.Entity<Service>().HasData(new Service()
            {
                Id = "5",
                RegInfoId = "1"
            });
            builder.Entity<Request>().HasData(new Request()
            {
                Id = "7",
                Command = 5,
                DeviceId = 2732,
                ReqNum = 1,
                Token = 46583490,
                ServiceId = "5"
            });
        }
    }
}