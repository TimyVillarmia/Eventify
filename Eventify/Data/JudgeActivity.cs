using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventify.Data
{
    public class JudgeActivity
    {
        [Key]
        public int ID { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Activity> Activities { get; } = new List<Activity>(); // Collection navigation containing dependents

    }
}