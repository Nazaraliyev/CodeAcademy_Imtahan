using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.Models
{
    public class Work
    {
        [Key]
        public int Id { get; set; }


        [MaxLength(250), Required]
        public string Photo { get; set; }


        [MaxLength(50), Required]
        public string Tittle { get; set; }


        [MaxLength(300), Required]
        public string Text { get; set; }
    }
}
