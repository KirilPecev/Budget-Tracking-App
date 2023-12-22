using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BtaApi.Domain
{
    public class BtaDbContext : IdentityDbContext<IdentityUser>
    {
        public BtaDbContext(DbContextOptions<BtaDbContext> options) : base(options) { }
    }
}
