using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventify.Data
{
    public class Participants
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Course { get; set; }

        [Required]
        public string Section { get; set; }

        [Required]
        public string EntryNumber { get; set; }

        public int ActivityID { get; set; }
        public Activity Activity { get; set; }

        public ICollection<ParticipantsScore> ParticipantsScores { get; set; }


    }








}

