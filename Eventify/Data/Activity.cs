using Eventify.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Eventify.Data
{
    public class Activity
    {

       


        public int Id { get; set; }  

        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public int EventID { get; set; } 
        public Events Event { get; set; } 

        [DataType(DataType.Date), Required]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        [DataType(DataType.Time), Required]
        public TimeOnly StartTime { get; set; }

        [DataType(DataType.Time), Required, CustomTimeValidation("StartTime")]
        public TimeOnly EndTime { get; set; }

        [Required]
        public string? Venue { get; set; }


        public ICollection<Participants> Participants { get; set; }
        public ICollection<Criteria> Criteria { get; set; }
        public ICollection<Result> Results { get; set; }
        public ICollection<JudgeActivity> Judges { get; set; }


    }
}
