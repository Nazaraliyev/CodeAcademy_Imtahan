using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.Models
{
    public class CustomUser:IdentityUser
    {
        [MaxLength(50), Required]
        public string Name { get; set; }



        [MaxLength(50), Required]
        public string Surname { get; set; }

    }
}
