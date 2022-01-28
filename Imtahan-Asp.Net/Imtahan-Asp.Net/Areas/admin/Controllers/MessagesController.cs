using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Imtahan_Asp.Net.Data;
using Imtahan_Asp.Net.Models;
using Microsoft.AspNetCore.Authorization;

namespace Imtahan_Asp.Net.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly AppDbContext _context;

        public MessagesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: admin/Messages
        public async Task<IActionResult> Index()
        {
            return View(await _context.messages.ToListAsync());
        }

        // GET: admin/Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.messages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }


        // GET: admin/Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = await _context.messages.FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }


            _context.messages.Remove(message);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }
    }
}
