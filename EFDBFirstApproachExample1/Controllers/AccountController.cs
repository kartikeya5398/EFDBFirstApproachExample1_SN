﻿using EFDBFirstApproachExample1.Identity;
using EFDBFirstApproachExample1.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Company.DomainModels;
using System.Web.Mvc;

namespace EFDBFirstApproachExample1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Register
        [HttpGet]
        [ActionName("Register")]
        public ActionResult RegistrationPage()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                //Register
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rvm.Password);
                var user = new ApplicationUser() { Email = rvm.Email, PasswordHash =passwordHash, UserName = rvm.UserName, City = rvm.City, Country = rvm.Country, PhoneNumber = rvm.Mobile, Address = rvm.Address, Birthday = rvm.DateOfBirth };
                IdentityResult result=userManager.Create(user);

                if (result.Succeeded)
                {
                    //Role
                    userManager.AddToRole(user.Id, "Customer");

                    //login
                    this.LoginUser(userManager, user);
                }

                return RedirectToAction("Index", "Home");
            }
            else 
            {
                ModelState.AddModelError("My Error", "Invalid Data");
                return View();
            }
        }

        //GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //POST: Account/Login
        [HttpPost]
        [OverrideExceptionFilters]
        public ActionResult Login(LoginViewModel lvm)
        {
            //Login
            var appDbContext = new ApplicationDbContext();                  //username=john, pass=john123
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var user =userManager.Find(lvm.UserName, lvm.Password);

            if (user != null)
            {
                //Login
                this.LoginUser(userManager, user);

                if (userManager.IsInRole(user.Id,"Admin"))
                {
                    return RedirectToAction("Index", "Home",new {area="Admin" });
                }
                else if (userManager.IsInRole(user.Id, "Manager"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Manager" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }
            else 
            {
                ModelState.AddModelError("MyError", "Invalid UserName or password");
                return View();
            }
            
        }

        [NonAction]
        public void LoginUser(ApplicationUserManager userManager, ApplicationUser user)
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
        }

        //GET: Account/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //GET: Account/MyProfile
        [HttpGet]
        public ActionResult MyProfile()
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser appUser= userManager.FindById(User.Identity.GetUserId());
            return View(appUser);
        }

    }
}