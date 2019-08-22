using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HSCFiscalRegistrar.Models
{
    public class ApplicationDBbContext : IdentityDbContext<User>
    {


        public ApplicationDBbContext(DbContextOptions<ApplicationDBbContext> options) : base(options)
        {
        }
    }
}