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

        public AccountController(AppDbContext context, SignInManager<CustomUser> signInManager, UserManager<CustomUser> userManager)
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
                return View(model);
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
            return View(model);
        }

        public async Task<IActionResult> Update(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            if (await _userManager.FindByIdAsync(Id) == null)
            {
                return NotFound();
            }


            CustomUser user = await _userManager.FindByIdAsync(Id);
            VmUserUpdate model = new VmUserUpdate()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Phone = user.PhoneNumber
            };

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Update(VmUserUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            CustomUser user = await _userManager.FindByIdAsync(model.Id);

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.UserName = model.Email;
            user.PhoneNumber = model.Phone;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            if (await _userManager.FindByIdAsync(Id) == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(await _userManager.FindByIdAsync(Id));
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();

        }




        public IActionResult Login()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(VmUserLogin model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            };

            var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Login or Password is not correct");
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }



    }
}
