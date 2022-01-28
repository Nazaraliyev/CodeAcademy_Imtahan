using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.ViewModel
{
    public class VmUserCreate
    {
        [MaxLength(50), Required]
        public string Name { get; set; }



        [MaxLength(50), Required]
        public string Surname { get; set; }


        [MaxLength(100), Required, EmailAddress]
        public string Email { get; set; }



        [MaxLength(15), Required, Phone]
        public string Phone { get; set; }


        [MaxLength(50), MinLength(5), Required,]
        public string Password { get; set; }



        [MaxLength(50), MinLength(5), Required, Compare("Password"), Display(Name = "Confirm Password")]
        public string CoPassword { get; set; }
    }
}
