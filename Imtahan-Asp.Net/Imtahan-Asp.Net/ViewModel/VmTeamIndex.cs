using Imtahan_Asp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.ViewModel
{
    public class VmTeamIndex
    {
        public List<Team> teams { get; set; }

        public int page { get; set; }

        public decimal count { get; set; }
    }
}
