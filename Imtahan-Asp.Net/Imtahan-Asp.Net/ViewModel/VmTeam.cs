using Imtahan_Asp.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.ViewModel
{
    public class VmTeam
    {
        public List<Team> teams { get; set; }
        public List<TeamPosition> teamPositions { get; set; }
        public int PositionId { get; set; }

    }
}
