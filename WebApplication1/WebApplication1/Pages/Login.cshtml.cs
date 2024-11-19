using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Respositories1.Entities;
using Services1.DTO;
using Services1.Interfaces;

namespace WebApplication1.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewData["ErrorMessage"] = "Error";
                    return Page();
                }

                //Khoi tao doi tuong 
                var loginUserInfo = new LoginDTO()
                {
                    Email = Request.Form["email"].ToString(),
                    Password = Request.Form["password"].ToString(),
                };
                var user = await _userService.checkLogin(loginUserInfo);
                if (user == null)
                {
                    ViewData["ErrorMessage"] = "Account does not exist";
                    return Page();
                }

                HttpContext.Session.SetString("UserId", user.UserId.ToString());
                HttpContext.Session.SetString("Username", user.UserName);
                return RedirectToPage("/Index");
            }
            catch (Exception)
            {
                return Page();
            }
        }
    }
}