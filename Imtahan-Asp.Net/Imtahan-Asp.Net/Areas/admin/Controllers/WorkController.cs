using Imtahan_Asp.Net.Data;
using Imtahan_Asp.Net.Models;
using Imtahan_Asp.Net.ViewModel;
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
    public class WorkController : Controller
    {
        private readonly AppDbContext _context;

        public WorkController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.works.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(VmWorkCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.PhotoFile.ContentType == "image/jpeg" || model.PhotoFile.ContentType == "image/png")
            {
                if (model.PhotoFile.Length > 3 * 1024 * 1024)
                {
                    ModelState.AddModelError("", "You can only upload Image until 3mb");
                    return View(model);
                }

                string fileName = Guid.NewGuid() + "-" + model.PhotoFile.FileName;
                string filePath = Path.Combine("wwwroot", "assets/img/work", fileName);
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

            Work work = new Work()
            {
                Photo = model.Photo,
                Tittle = model.Tittle,
                Text = model.Text
            };


            _context.works.Add(work);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



    }
}
