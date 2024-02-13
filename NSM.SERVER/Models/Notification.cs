using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSM.SERVER.Models
{
    public class Notification
    {

        [Key]
        public int Id { get; set; }

        [Required,MaxLength(500)]
        public string Description { get; set; }

        public User UserKey { get; set; }

        [ForeignKey("UserKey")]
        public int UserId { get; set; }


    }
}
