using System.ComponentModel.DataAnnotations.Schema;

namespace NSM.SERVER.Models
{
    class ChatUser
    {

        public int Id { get; set; }

        public Chat ChatKey { get; set; }

        public User UserKey { get; set; }

        [ForeignKey("UserKey")]
        public int UserId { get; set; }

        [ForeignKey("ChatKey")]
        public int ChatId { get; set; }

    }
}
