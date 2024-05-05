using Eventify.DataAnnotations;
using System.ComponentModel.DataAnnotations;
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
        public DateTime Date { get; set; }

        [DataType(DataType.Time) , Required]
        public TimeOnly StartTime { get; set; }

        [DataType(DataType.Time ), Required]
        public TimeOnly EndTime { get; set; }

        [Required]
        public string? Venue { get; set; }
    }
}
