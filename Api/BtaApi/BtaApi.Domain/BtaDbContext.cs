using Microsoft.EntityFrameworkCore;

namespace BtaApi.Domain
{
    public class BtaDbContext : DbContext
    {
        public BtaDbContext(DbContextOptions<BtaDbContext> options) : base(options) { }
    }
}
