using Eventify.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Eventify.Data
{
    public class Criteria
    {
        public int Id { get; set; }

        [Required]
        public string CriteriaName { get; set; }

        public int ActivityID { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double MaxScore { get; set; }


        public Activity Activity { get; set; }





















    }
}
