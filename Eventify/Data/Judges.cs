using Eventify.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Eventify.Data
{
    public class Judges
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Activity Activity { get; set; }

    }
}
