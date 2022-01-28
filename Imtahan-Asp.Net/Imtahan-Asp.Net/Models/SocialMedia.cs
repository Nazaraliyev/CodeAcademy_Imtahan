﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.Models
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }



        [MaxLength(50), Required]
        public string Name { get; set; }



        [MaxLength(50), Required]
        public string Icon { get; set; }



        [MaxLength(300), Required]
        public string Link { get; set; }



        [MaxLength(10), Required]
        public string Color { get; set; }
    }
}
