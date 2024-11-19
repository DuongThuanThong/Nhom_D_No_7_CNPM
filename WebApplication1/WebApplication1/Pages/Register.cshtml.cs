using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Respositories1.Entities;
using Services1.DTO;
using Services1.Interfaces;
namespace WebApplication1.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;
        public RegisterModel(IUserService userService)
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

                var registerUserInfo = new RegisterDTO()
                {
                    UserName = Request.Form["userName"].ToString(),
                    Email = Request.Form["email"].ToString(),
                    Password = Request.Form["password"].ToString(),
                    Phone = Request.Form["phone"].ToString(),
                };

                
                if (await _userService.isEmailExists(registerUserInfo.Email))
                {
                    ViewData["ErrorMessage"] = "The email is already registered.";
                    return Page();
                }

                if (await _userService.isPhoneExists(registerUserInfo.Phone))
                {
                    ViewData["ErrorMessage"] = "The phone number is already registered.";
                    return Page();
                }




                var register = await _userService.AddUser(registerUserInfo);
                if (register)
                {

                    
                    HttpContext.Session.SetString("UserId", registerUserInfo.Email);
                    HttpContext.Session.SetString("Username", registerUserInfo.UserName);

                    return RedirectToPage("/Index");
                }
                else
                {
                    ViewData["ErrorMessage"] = "Please try again!";
                    return Page();
                }
            }
            catch (Exception)
            {
                return Page();
            }
        }
    }

}

