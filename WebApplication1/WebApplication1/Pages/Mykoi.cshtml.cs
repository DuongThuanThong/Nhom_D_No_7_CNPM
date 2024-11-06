using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Respositories1.Models;
using Services1.Interfaces;

namespace WebApplication1.Pages
{
    public class MykoiModel : PageModel
    {
        private readonly IKoiService _koiService;
        private readonly IGrowthKoiService _growththKoiService;

        public MykoiModel(IKoiService koiService, IGrowthKoiService growthKoiService)
        {
            _koiService = koiService;
            _growththKoiService = growthKoiService;
        }
        public async Task<IActionResult> OnPost()
        {
            var name = Request.Form["Name"].FirstOrDefault();

            int gender = 0;
            if (Request.Form["Sex"] == "Male")
            {
                gender = 1;
            }

            var breed = Request.Form["Breed"].FirstOrDefault();
            var origin = Request.Form["Origin"].FirstOrDefault();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(breed) || string.IsNullOrEmpty(origin)) 
            {
                ModelState.AddModelError(string.Empty, "Please Enter Complete Information.");
                return Page();
            }

            var newKoi = new Koi
            {
                Name = name,
                Gender = gender,
                Breed = breed,  
                Origin = origin
            };
           
            bool isKoiAdd = await _koiService.AddKoi(newKoi);
            if (!isKoiAdd)
            {
                ModelState.AddModelError(string.Empty, "Add Koi False. Please Try Again.");
            }

            int koiId = newKoi.KoiId;

            float size = float.TryParse(Request.Form["Size"], out float sizeValue) ? sizeValue : 0;
            float weight = float.TryParse(Request.Form["Weight"], out float  weightValue) ? weightValue : 0;    
            var body= Request.Form["Body"].FirstOrDefault();
            int age = int.TryParse(Request.Form["Age"], out int ageValue) ? ageValue : 0;
            float price = float.TryParse(Request.Form["Price"], out float  priceValue) ? priceValue : 0;

            if (size == 0 || weight == 0)
            {
                ModelState.AddModelError(string.Empty, "Please Enter Complete Information.");
            }

            var newGrowthKoi = new GrowthKoi
            {
                KoiId = koiId,
                Size = size,
                Weight = weight,
                BodyShape = body,
                Age = age,
                Price = price,
            };

            bool isGrowthKoiAdd = await _growththKoiService.AddGrowthKoi(newGrowthKoi);
            if (!isGrowthKoiAdd)
            {
                ModelState.AddModelError(string.Empty, "Add Koi False. Please Try Again.");
            }

            ModelState.AddModelError(string.Empty, "Add Koi Success.");
            return Page();
        }
    }
}
