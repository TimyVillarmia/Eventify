using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventify.Data
{
    public class JudgeActivity
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("Activity")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}