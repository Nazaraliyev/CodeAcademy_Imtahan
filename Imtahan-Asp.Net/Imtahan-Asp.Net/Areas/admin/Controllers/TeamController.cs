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


        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            if (await _context.teams.FindAsync(Id) == null)
            {
                return NotFound();
            }

            Team member = await _context.teams.FindAsync(Id);

            VmTeamUpdate model = new VmTeamUpdate()
            {
                Id = member.Id,
                Name = member.Name,
                Content = member.Content,
                PositionId = member.TeamPositionId,
                Photo = member.Photo,
                teamPositions = await _context.teamPositions.ToListAsync(),
            };

            return View(model); 
        }


        [HttpPost]
        public IActionResult Update(VmTeamUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(model.PhotoFile != null)
            {
                if (model.PhotoFile.ContentType == "image/jpeg" || model.PhotoFile.ContentType == "image/png")
                {
                    if (model.PhotoFile.Length > 3 * 1024 * 1024)
                    {
                        ModelState.AddModelError("", "You can only upload Image until 3mb");
                        return View(model);
                    }


                    string oldImage = Path.Combine(_webHost.WebRootPath, "assets/img/team", model.Photo);
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }


                    string fileName = Guid.NewGuid() + "-" + model.PhotoFile.FileName;
                    string filePath = Path.Combine(_webHost.WebRootPath, "assets/img/team", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
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
            }

            Team member = new Team()
            {
                Id = model.Id,
                Name = model.Name,
                Content = model.Content,
                Photo = model.Photo,
                TeamPositionId = model.PositionId
            };

            _context.teams.Update(member);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            if (await _context.teams.FindAsync(Id) == null)
            {
                return NotFound();
            }

            Team willDeleteMemver = await _context.teams.FindAsync(Id);

            string Image = Path.Combine(_webHost.WebRootPath, "assets/img/team", willDeleteMemver.Photo);
            if (System.IO.File.Exists(Image))
            {
                System.IO.File.Delete(Image);
            }

            _context.teams.Remove(willDeleteMemver);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));


        }
    }
}
