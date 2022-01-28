using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.ViewModel
{
    public class VmWorkUpdate
    {
        public int Id { get; set; }


        [MaxLength(250)]
        public string Photo { get; set; }


        [MaxLength(50), Required]
        public string Tittle { get; set; }


        [MaxLength(300), Required]
        public string Text { get; set; }


        public IFormFile PhotoFile { get; set; }
    }
}
