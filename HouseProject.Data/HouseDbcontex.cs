using HouseProject.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace HouseProject.Data
{
    public class HouseDbcontext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
    {
        public HouseDbcontext(DbContextOptions<HouseDbcontext> options)
            : base(options) { }

        public DbSet<House> House { get; set; }
    }
}
