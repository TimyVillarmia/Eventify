using Eventify.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Eventify.Data
{
    public class Activity
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public int EventID { get; set; }      
        public Events Event { get; set; }         

        [DataType(DataType.Date), Required, CustomDateAttribute]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        [DataType(DataType.Time), Required]
        public TimeOnly StartTime { get; set; }

        [DataType(DataType.Time), Required, CustomTimeValidation("StartTime")]
        public TimeOnly EndTime { get; set; }

        [Required]
        public string? Venue { get; set; }
    }
}
