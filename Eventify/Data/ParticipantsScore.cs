using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventify.Data
{
    public class ParticipantsScore
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Score { get; set; }

        [ForeignKey("Criteria")]
        public int CriteriaId { get; set; }
        public Criteria Criteria { get; set; }

        [ForeignKey("Participants")]
        public int ParticipantId { get; set; }
        public Participants Participant { get; set; }

        [ForeignKey("Judge")]
        public int JudgedBy { get; set; }
        public JudgeActivity Judge { get; set; }
    }
}