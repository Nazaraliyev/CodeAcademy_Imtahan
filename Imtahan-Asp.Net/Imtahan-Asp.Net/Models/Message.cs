using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }



        [MaxLength(100), Required]
        public string Name { get; set; }



        [MaxLength(100), Required, EmailAddress]
        public string Email { get; set; }


        [Required, Phone, MaxLength(15)]
        public string Phone { get; set; }



        [MaxLength(1000), Required]
        public string Content { get; set; }

    }
}
