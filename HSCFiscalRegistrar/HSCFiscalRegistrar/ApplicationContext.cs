using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.APKInfo;

namespace HSCFiscalRegistrar
{
    public sealed class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Kkm> Kkms { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<ShiftOperation> ShiftOperations { get; set; }
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
                TerminalNumber = "",
                DeviceId = 2732,
                OfdToken = 51902878,
                ReqNum = 100,
                Address = "135 Amangeldi street"
            });
            builder.Entity<User>().HasData(new User
            {
                Id = "3",
                Okved = "",
                TaxationType = 0,
                Inn = "160840027676",
                Title = "Bill",
                Name = "TOO ROGA&KOPITA",
                VAT = true,
                VATNumber = "1231212",
                VATSeria = "32132"
            });
            builder.Entity<User>().HasData(new User
            {
                Id = "1",
                Name = "Ibragim",
                Code = 228,
                KkmId = "2",
            });
        }
    }
}