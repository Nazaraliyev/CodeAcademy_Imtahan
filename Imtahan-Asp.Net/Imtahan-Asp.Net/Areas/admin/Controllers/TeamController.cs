using Imtahan_Asp.Net.Data;
using Imtahan_Asp.Net.Models;
using Imtahan_Asp.Net.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.Areas.admin.Controllers
{
    [Area("admin")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public TeamController(AppDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }



        public async Task<IActionResult> Index(int page = 0)
        {
            int Count = 2;
            VmTeamIndex model = new VmTeamIndex()
            {
                teams = await _context.teams.Include(t => t.TeamPosition).Skip(Count * page).Take(Count).ToListAsync(),
                page = page,
                count =  Math.Ceiling((decimal)_context.teams.Count()/Count),
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



        [HttpPost]
        public async Task<IActionResult> Create(VmTeamCreate model)
        {
            model.teamPositions =await _context.teamPositions.ToListAsync();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

           if(model.PhotoFile.ContentType == "image/jpeg" || model.PhotoFile.ContentType == "image/png")
            {
                if(model.PhotoFile.Length > 3 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "You can only upload Image until 3mb");
                    return View(model);
                }

                string fileName = Guid.NewGuid() + "-" + model.PhotoFile.FileName;
                string filePath = Path.Combine(_webHost.WebRootPath, "assets/img/team", fileName);
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.PhotoFile.CopyTo(stream);
                }

                model.Photo = fileName;
            }
            else
            {
                ModelState.AddModelError("", "You can only upload image file");
                return View(model);
            }

            Team member = new Team()
            {
                Name = model.Name,
                Content = model.Content,
                Photo = model.Photo,
                TeamPositionId = model.PositionId
            };

            _context.teams.Add(member);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
