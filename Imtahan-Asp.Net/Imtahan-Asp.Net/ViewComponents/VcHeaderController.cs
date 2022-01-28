using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.ViewComponents
{
    public class VcHeaderController:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
