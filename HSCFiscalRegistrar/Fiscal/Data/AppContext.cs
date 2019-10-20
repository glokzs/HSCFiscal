﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Fiscal.Data
{
    public class AppContext : IdentityDbContext<User>
    {
        public DbSet<Kkm> Kkms { get; set; }
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseLazyLoadingProxies();
    }
}