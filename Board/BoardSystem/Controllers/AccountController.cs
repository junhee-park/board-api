﻿using System;
using System.Linq;
using BoardSystem.DataContext;
using BoardSystem.Models;
using BoardSystem.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoardSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            string a = model.UserLogin;
            if(model.UserLogin.Equals("0"))
            {
                
                ModelState.AddModelError(string.Empty, "ユーザーのIDもしくはパスワードが正しくありません。");
                return View(model);
            }
            HttpContext.Session.SetString("USER_LOGIN_KEY", model.UserId);
            return RedirectToAction("Index", "Home");
            //return View(model);
        }
        

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if(ModelState.IsValid)
            {
                //RedirectToAction("Error", "Home");
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
