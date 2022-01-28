using Imtahan_Asp.Net.Data;
using Imtahan_Asp.Net.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.Areas.admin.Controllers
{
    [Area("admin")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index(int page = 0)
        {
            int Count = 6;
            VmTeamIndex model = new VmTeamIndex()
            {
                teams = await _context.teams.Include(t =>t.TeamPosition).Skip(Count*page).Take(Count).ToListAsync(),
                page = page,
                count = Count
            };
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            VmTeamCreate model = new VmTeamCreate()
            {
                teamPositions = await _context.teamPositions.ToListAsync(),
            };

            return View(model);
        }
    }
}
