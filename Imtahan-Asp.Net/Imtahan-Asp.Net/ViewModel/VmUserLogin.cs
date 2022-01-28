using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.ViewModel
{
    public class VmUserLogin
    {
        [MaxLength(100), Required, EmailAddress]
        public string Login { get; set; }


        [MaxLength(100), Required]
        public string Password { get; set; }
    }
}
