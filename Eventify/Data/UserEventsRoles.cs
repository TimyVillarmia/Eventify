using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Eventify.Data
{
    public class UserEventsRoles
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public Events Event { get; set; }
        public virtual IdentityRole Roles { get; set; }
    }
}
