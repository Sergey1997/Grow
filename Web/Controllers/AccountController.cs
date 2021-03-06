﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Models.GoalModels;
using Web.Models.UserModels;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _context = new ApplicationContext();

        public AccountController()
        {
        }

        public AccountController(ApplicationContext context)
        {
            _context = context;
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // если создание прошло успешно, то добавляем роль пользователя
                    await UserManager.AddToRoleAsync(user.Id, "Mentor");
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    return RedirectToAction("Index", "Home");
                }
                //AddErrors(result);
            }
            
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult MyGoals()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var email = HttpContext.User.Identity.Name;
            var user = UserManager.Users.Where(p => p.Email == email).SingleOrDefault();

            var goalsofUser = user.Goals.ToList();

            return View(goalsofUser);
        }

        public string GetInfo()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var email = HttpContext.User.Identity.Name;
            var user = UserManager.Users.Where(p => p.Email == email).SingleOrDefault();
            var dateOfCreating = UserManager.Users.Where(p => p.Email == email).Select(s => s.DateOfCreation);
            return "<p>Эл. адрес: " + email + "</p><p> Дата создания:" + user.DateOfCreation + "</p>";
        }
        [HttpGet]
        public ActionResult AddGoal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddGoal(Goal viewModel)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var email = HttpContext.User.Identity.Name;
            var user = UserManager.Users.Where(p => p.Email == email).SingleOrDefault();
            var goal = new Goal()
            {
                DeadlineDate = viewModel.DeadlineDate,
                Description = viewModel.Description,
                FinishDate = viewModel.FinishDate,
                StartDate = viewModel.StartDate,
                IsCompleted = viewModel.IsCompleted,
                StatusOfGoal = viewModel.StatusOfGoal,
                UserId = user.Id
            };

            _context.Goals.Add(goal);
            _context.SaveChanges();

            return RedirectToAction("MyGoals");
        }
        
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await UserManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (String.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        //EDIT AND DELETING OF USERS
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed()
        {
            User user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Logout", "Account");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Edit()
        {
            User user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                EditModel model = new EditModel { DateOfCreating = user.DateOfCreation };
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditModel model)
        {
            User user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                user.DateOfCreation = model.DateOfCreating;
                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }

            return View(model);
        }
    }
}