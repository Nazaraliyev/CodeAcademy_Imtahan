using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }



        [MaxLength(250)]
        public string Logo { get; set; }



        [MaxLength(250)]
        public string BannerBackImg { get; set; }


        [MaxLength(250)]
        public string BannerImg { get; set; }


        [MaxLength(50)]
        public string BannerHeader { get; set; }


        [MaxLength(200)]
        public string BannerContent { get; set; }



        [MaxLength(100)]
        public string AboutHeader { get; set; }



        [MaxLength(1000)]
        public string AboutContent { get; set; }



        [MaxLength(250)]
        public string AboutImg { get; set; }




        [MaxLength(500)]
        public string FooterContent { get; set; }



        [MaxLength(100),EmailAddress]
        public string FooterEmail { get; set; }


        [MaxLength(15), Phone]
        public string FooterPhone { get; set; }


    }
}
