using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.ViewModel
{
    public class VmWorkCreate
    {
        [MaxLength(250)]
        public string Photo { get; set; }


        [MaxLength(50), Required]
        public string Tittle { get; set; }


        [MaxLength(300), Required]
        public string Text { get; set; }


        [Required]
        public IFormFile PhotoFile { get; set; }
    }
}
