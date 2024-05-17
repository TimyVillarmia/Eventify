using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventify.Data
{
    public class Result
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public int ActivityId { get; set; }
        public double OverallScore { get; set; }
        public Participants Participant { get; set; }
        public Activity Activity { get; set; }


    }
}