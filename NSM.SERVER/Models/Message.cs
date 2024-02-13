using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSM.SERVER.Models
{
    class Message
    {

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(1500)]
        public string Content { get; set; }

        public Chat ChatKey { get; set; }

        [ForeignKey("ChatKey")]
        public int ChatId { get; set; }

    }
}
