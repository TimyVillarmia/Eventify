using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventify.Data
{
    public class Result
    {
        public int Id { get; set; }

        [ForeignKey("Participant")]
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
         
        [ForeignKey("Activity")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        [Required]
        public double OverallScore { get; set; }
    }
}