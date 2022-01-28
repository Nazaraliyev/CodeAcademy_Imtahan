using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }



        [MaxLength(100), Required]
        public string Name { get; set; }



        [MaxLength(100), Required]
        public string Position { get; set; }



        [MaxLength(300), Required]
        public string Content { get; set; }


        [MaxLength(250), Required]
        public string Photo { get; set; }

    }
}
