using Imtahan_Asp.Net.Data;
using Imtahan_Asp.Net.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class SocialMediaController : Controller
    {
        private readonly AppDbContext _context;

        public SocialMediaController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.socialMedias.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(SocialMedia model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _context.socialMedias.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Update(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            if (await _context.socialMedias.FindAsync(Id) == null)
            {
                return NotFound();
            }


            return View(await _context.socialMedias.FindAsync(Id));
        }


        [HttpPost]
        public IActionResult Update(SocialMedia model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _context.socialMedias.Update(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            if (await _context.socialMedias.FindAsync(Id) == null)
            {
                return NotFound();
            }

            _context.socialMedias.Remove(await _context.socialMedias.FindAsync(Id));
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
