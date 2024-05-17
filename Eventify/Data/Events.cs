using Eventify.DataAnnotations;
using Humanizer.Localisation;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Eventify.Data
{
    public class Events
    {
        public int Id { get; set; }

        [Required]
        public string? EventName { get; set; }

        [Required]
        public string? Status { get; set; }

        [DataType(DataType.Date), Required, CustomDateAttribute]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        [DataType(DataType.Time) , Required]
        public TimeOnly StartTime { get; set; }

        [DataType(DataType.Time ), Required, CustomTimeValidation("StartTime")]
        public TimeOnly EndTime { get; set; }

        [Required]
        public string? Venue { get; set; }

        public string? ACCESS_CODE { get; set; }

        // For One to Many Relatioship  
        public ICollection<Activity> Activities { get; set; }

    }
}
