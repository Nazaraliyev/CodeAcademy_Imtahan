using Imtahan_Asp.Net.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.ViewModel
{
    public class VmTeamCreate
    {
        [MaxLength(100), Required]
        public string Name { get; set; }



        [MaxLength(300), Required]
        public string Content { get; set; }



        [Required]
        public IFormFile PhotoFile { get; set; }


        public string Photo { get; set; }



        public List<TeamPosition> teamPositions { get; set; }

        [Required, Display(Name = "Position")]
        public int PositionId { get; set; }

    }
}
