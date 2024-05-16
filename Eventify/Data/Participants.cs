using System.ComponentModel.DataAnnotations;

namespace Eventify.Data
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //one to many relationship
        public ICollection<Result> Results { get; set; }
    }
}