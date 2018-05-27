using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Course_Work.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Course_Work.ViewModels;
using Course_Work.Services;
using Course_Work.Context;

namespace Course_Work.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private dbcontext db;
        public static string currid;//текущий id

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, dbcontext dbcontext)
        {
            db = dbcontext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            /* if (ModelState.IsValid)
             {
                 User user = new User { Email = model.Email, UserName = model.Email };
                 // добавляем пользователя
                 var result = await _userManager.CreateAsync(user, model.Password);
                 if (result.Succeeded)
                 {
                     var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                     var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                         new { userId = user.Id, code = code },
                         protocol: HttpContext.Request.Scheme);
                     EmailService emailService = new EmailService();
                     await emailService.SendEmailAsync(model.Email, "Confirm your account",
                     $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");


                     return RedirectToAction("Index", "Home");
                 }
                 else
                 {
                     foreach (var error in result.Errors)
                     {
                         ModelState.AddModelError(string.Empty, error.Description);
                     }
                 }
             }
             return View(model);
             */
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByNameAsync(model.Email);

                /*
                if (user != null)
                {
                    // проверяем, подтвержден ли email
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "Вы не подтвердили свой email");
                        return View(model);
                    }
                }
                */

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    //получаем текущий id пользователя.
                    currid = _userManager.GetUserId(HttpContext.User);
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LogOff()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        
        public IActionResult UserInfo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserInfo(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var users = db.Users.Where(t => t.UserName == username).FirstOrDefault();
            var orders = db.Order.Where(t => t.UserId == users.Id).ToList();
            
            //столько времени работы ради трех строк.....
            List<UserInfoViewModel.forview> qwe= ( from main in orders
                     join aux in db.Shops on main.ShopId equals aux.Id
                     select new UserInfoViewModel.forview{ Name=aux.Name, DateOfOrder=main.DateOfOrder, Adress=main.Adress}).ToList();


            UserInfoViewModel userInfo = new UserInfoViewModel
            {
                User = user,
                Orders = orders,
                fview = qwe
            };

                return View(userInfo);
            }

    }
}