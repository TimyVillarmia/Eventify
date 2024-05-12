using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Eventify.Data;

namespace Eventify.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Eventify.Data.Events> Events { get; set; } = default!;
        public DbSet<Eventify.Data.Activity> Activity { get; set; } = default!;
        public DbSet<Eventify.Data.UserEventsRoles> UserEventsRoles { get; set; } = default!;
    }
}
