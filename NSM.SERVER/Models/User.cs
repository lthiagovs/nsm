using System.ComponentModel.DataAnnotations;

namespace NSM.SERVER.Models
{
    class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Login { get; set; }

        [Required, MaxLength(50)]
        public string Password { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Photo { get; set; }


    }
}
