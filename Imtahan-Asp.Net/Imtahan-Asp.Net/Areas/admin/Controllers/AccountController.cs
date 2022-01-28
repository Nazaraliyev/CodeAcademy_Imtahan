using Imtahan_Asp.Net.Data;
using Imtahan_Asp.Net.Models;
using Imtahan_Asp.Net.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imtahan_Asp.Net.Areas.admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly UserManager<CustomUser> _userManager;

        public AccountController(AppDbContext context, SignInManager<CustomUser> signInManager, UserManager<CustomUser> userManager )
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.ToListAsync());
        }



        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(VmUserCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            CustomUser user = new CustomUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.Phone
            };


            var result = await _userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }




        public IActionResult Login()
        {
            return View();
        }
    }
}
