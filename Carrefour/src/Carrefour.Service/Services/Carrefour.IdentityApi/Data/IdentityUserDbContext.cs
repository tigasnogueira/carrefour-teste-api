using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Carrefour.IdentityApi.Data
{
    public class IdentityUserDbContext : IdentityDbContext<IdentityUser>
    {
        public IdentityUserDbContext(DbContextOptions<IdentityUserDbContext> options) : base(options) { }
    }
}
