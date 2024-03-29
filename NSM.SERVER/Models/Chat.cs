﻿using System.ComponentModel.DataAnnotations;

namespace NSM.SERVER.Models
{
    public class Chat
    {

        [Key]
        public int Id { get; set; }

        [Required,MaxLength(100)]
        public string Name { get; set; }

    }
}
