using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.ViewModel
{
    public class VmUserResetPass
    {

        [MaxLength(100), MinLength(5), Required,]
        public string Password { get; set; }



        [MaxLength(100), MinLength(5), Required, Compare("Password"), Display(Name = "Confirm Password")]
        public string CoPassword { get; set; }
    }
}
