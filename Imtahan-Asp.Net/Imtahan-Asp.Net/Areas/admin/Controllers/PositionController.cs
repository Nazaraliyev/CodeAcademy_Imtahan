using Imtahan_Asp.Net.Data;
using Imtahan_Asp.Net.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class PositionController : Controller
    {
        private readonly AppDbContext _context;

        public PositionController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.teamPositions.ToListAsync());
        }




        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(TeamPosition model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(await _context.teamPositions.AnyAsync(tp => tp.Name == model.Name))
            {
                ModelState.AddModelError("", "This Position has exist in Position List");
                return View(model);
            }

            var result = _context.teamPositions.Add(model);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Update(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }

            if(await _context.teamPositions.FindAsync(Id) == null)
            {
                return NotFound();
            }

            return View(await _context.teamPositions.FindAsync(Id));
        }


        [HttpPost]
        public async Task<IActionResult> Update(TeamPosition model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _context.teamPositions.AnyAsync(tp => tp.Name == model.Name))
            {
                if (_context.teamPositions.FirstOrDefault(tp => tp.Name == model.Name).Id == model.Id)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "This Position has exist in Position List");
                return View(model);
            }

            _context.teamPositions.Update(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Delete(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }

            if(! await _context.teamPositions.AnyAsync(tp => tp.Id == Id))
            {
                return NotFound();
            }

            TeamPosition position = await _context.teamPositions.FindAsync(Id);

            _context.teamPositions.Remove(position);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
