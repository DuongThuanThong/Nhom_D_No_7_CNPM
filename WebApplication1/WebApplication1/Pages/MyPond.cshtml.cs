using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Respositories1.Entities;
using Services1.DTO;
using Services1.Interfaces;

namespace WebApplication1.Pages
{
    public class MyPondModel : PageModel
    {
       

        private readonly IPondService _pondService;

        public MyPondModel(IPondService pondService)
        {
            _pondService = pondService;
        }


        public List<PondDTO> GetListPonds { get; set; } = new List<PondDTO>();


        public async Task<IActionResult> OnGet()
        {
            var userIdString = HttpContext.Session.GetString("UserId");
            if (userIdString == null)
            {
                return RedirectToPage("/Login");
            }
            else
            {
                int.TryParse(userIdString, out int userId);
                GetListPonds = await _pondService.GetAllPond(userId);
            }

            

            return Page();
        }

        [BindProperty]
        public PondDTO newPond { get; set; } = new PondDTO();

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewData["ErrorMessage"] = "Invalid data. Please check the form and try again.";
                    return Page();
                }
                Console.WriteLine("ModelState is valid.");
                //Kiem tra co dang nhap chua, chua dang nhap tra ve trang login
                var userIdString = HttpContext.Session.GetString("UserId");
                if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                {
                    return RedirectToPage("/Login");
                }


                newPond.UserId = userId;

        
                var pondImage = Request.Form.Files["Img"];
                if (pondImage != null && pondImage.Length > 0)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var fileExtension = Path.GetExtension(pondImage.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ViewData["ErrorMessage"] = "Invalid image format. Only JPG, JPEG, PNG, and GIF are allowed.";

                        return Page();
                    }

                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "pond");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + pondImage.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await pondImage.CopyToAsync(fileStream);
                    }

                    newPond.Image = $"/img/pond/{uniqueFileName}";

                }

                bool pondId = await _pondService.AddPond(newPond);
                if (!pondId)
                {
                    ViewData["ErrorMessage"] = "Failed to add Pond. Please try again.";

                    return Page();
                }

                return RedirectToPage();
            }
            catch (Exception)
            {

                ViewData["ErrorMessage"] = "Error. Please try again.";
                return Page();
            }
        }
    }
}