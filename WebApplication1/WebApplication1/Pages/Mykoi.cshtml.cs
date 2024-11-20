using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Respositories1.Entities;
using Services1;
using Services1.DTO;
using Services1.Interfaces;
using System.IO;

namespace WebApplication1.Pages
{
    public class MykoiModel : PageModel
    {
        private readonly IKoiService _koiService;
        private readonly IGrowthKoiService _growthKoiService;
        private readonly IPondService _pondService;

        public MykoiModel(IKoiService koiService, IGrowthKoiService growthKoiService, IPondService pondService)
        {
            _koiService = koiService;
            _growthKoiService = growthKoiService;
            _pondService = pondService;
        }

        public List<PondDTO> GetListPonds { get; set; } = new List<PondDTO>();
        public List<KoiDTO> GetListKois { get; set; } = new List<KoiDTO>();
        public Dictionary<int, GrowthKoiDTO?> ListLastGrowthKois { get; set; } = new Dictionary<int, GrowthKoiDTO?>() ;
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
                GetListKois = await _koiService.GetAllKoi(userId);

                foreach (var koi in GetListKois)
                {
                    var lastestGrowKoi = await _growthKoiService.GetGrowthKoi(koi.KoiId); ;
                    ListLastGrowthKois[koi.KoiId] = lastestGrowKoi;
                }
            }


            return Page();
        }
        public KoiDTO NewKoi { get; set; } = new KoiDTO();

        public GrowthKoiDTO NewGrowthKoi { get; set; } = new GrowthKoiDTO();

        public async Task<IActionResult> OnPost()
        {
            try
            {

                // Kiểm tra tính hợp lệ của ModelState
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                var userIdString = HttpContext.Session.GetString("UserId");
                if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                {
                    return RedirectToPage("/Login");
                }
                NewKoi.UserId = userId;
                var pondIdString = Request.Form["SelectedPondId"];
                if (int.TryParse(pondIdString, out int pondId))
                {
                    NewKoi.PondId = pondId;
                }
                NewKoi.Name = Request.Form["Name"].ToString();
                NewKoi.Gender = Request.Form["Sex"] == "Male" ? 1 : 0;
                NewKoi.Breed = Request.Form["Breed"].ToString();
                NewKoi.Origin = Request.Form["Origin"].ToString();


                // Thêm mới Koi vào database
                int newKoiId = await _koiService.AddKoi(NewKoi);
                if (newKoiId <= 0)
                {
                    ModelState.AddModelError(string.Empty, "Failed to add Koi. Please try again.");
                    return Page();
                }

                
                NewGrowthKoi.KoiId = newKoiId;
                NewGrowthKoi.Size = double.TryParse(Request.Form["Size"], out double size) ? size : 0;
                NewGrowthKoi.Weight = double.TryParse(Request.Form["Weight"], out double weight) ? weight : 0;
                NewGrowthKoi.BodyShape = Request.Form["Body"].ToString();
                NewGrowthKoi.Age = int.TryParse(Request.Form["Age"], out int age) ? age : 0;
                NewGrowthKoi.Price = double.TryParse(Request.Form["Price"], out double price) ? price : 0;

               
                var koiImage = Request.Form.Files["Img"];
                if (koiImage != null && koiImage.Length > 0)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var fileExtension = Path.GetExtension(koiImage.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                       
                        return Page();
                    }

                 
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "koi");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + koiImage.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

              
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await koiImage.CopyToAsync(fileStream);
                    }

                 
                    NewGrowthKoi.Image = $"/img/koi/{uniqueFileName}";
                }
                else
                {
                   
                    return Page();
                }

                // Thêm mới GrowthKoi vào database
                bool isGrowthKoiAdded = await _growthKoiService.AddGrowthKoi(NewGrowthKoi);
                if (!isGrowthKoiAdded)
                {
                    
                    return Page();
                }


                return RedirectToPage();
            }
            catch (Exception)
            {
                return RedirectToPage();
            }
        }
    }
}
