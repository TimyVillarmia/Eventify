using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventify.Data
{
    public class ParticipantsScore
    {
        public int Id { get; set; }
        [Required]
        public double Score { get; set; }
        public int CriteriaId { get; set; }
        public int ParticipantId { get; set; }
        public string JudgeId { get; set; }
        public Criteria Criteria { get; set; }
        public Participants Participant { get; set; }
        public ApplicationUser Judge { get; set; }
    }
}