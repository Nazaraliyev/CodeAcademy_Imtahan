using Imtahan_Asp.Net.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.ViewComponents
{
    public class VcFooterController : ViewComponent
    {
        private readonly AppDbContext _context;

        public VcFooterController(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
