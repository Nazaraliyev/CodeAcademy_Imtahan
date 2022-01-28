using Imtahan_Asp.Net.Data;
using Imtahan_Asp.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.Areas.admin.Controllers
{
    [Area("admin")]
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
    }
}
