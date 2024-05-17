using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventify.Data
{
    public class Participants
    {
        [Key]
        public int Id { get; set; }

        [Required]
        
        public string Name { get; set; }

        [Required]
       
        public string Course { get; set; }

        [Required]
      
        public string Section { get; set; }

        [Required]
   
        public string EntryNumber { get; set; }

        [ForeignKey("Activity")]
        public int ActivityId { get; set; }

        public Activity Activity { get; set; }




    }








}

