using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventify.Data
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Participants")]
        public int ParticipantId { get; set; }
        public Participants Participant { get; set; }

        [ForeignKey("Activity")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        [Required]
        public double OverallScore { get; set; }
    }
}