using Eventify.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventify.Data
{
    public class Criteria
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string CriteriaName { get; set; }

        [ForeignKey("Activity")]
        public int ActivityID { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double MaxScore { get; set; }























    }
}
