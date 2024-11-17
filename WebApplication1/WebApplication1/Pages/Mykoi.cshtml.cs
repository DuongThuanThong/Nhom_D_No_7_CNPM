using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Respositories1.Entities;
using Services1.Interfaces;
using System.IO;

namespace WebApplication1.Pages
{
    public class MykoiModel : PageModel
    {
        private readonly IKoiService _koiService;
        private readonly IGrowthKoiService _growthKoiService;

        [BindProperty]
        public Koi NewKoi { get; set; } = new Koi();

        [BindProperty]
        public GrowthKoi NewGrowthKoi { get; set; } = new GrowthKoi();

        public MykoiModel(IKoiService koiService, IGrowthKoiService growthKoiService)
        {
            _koiService = koiService;
            _growthKoiService = growthKoiService;
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {

                // Kiểm tra tính hợp lệ của ModelState
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                // Lấy dữ liệu từ Request.Form
                NewKoi.Name = Request.Form["Name"].ToString();
                NewKoi.Gender = Request.Form["Sex"] == "Male" ? 1 : 0;
                NewKoi.Breed = Request.Form["Breed"].ToString();
                NewKoi.Origin = Request.Form["Origin"].ToString();

                // Kiểm tra thông tin cần thiết
                if (string.IsNullOrWhiteSpace(NewKoi.Name) ||
                    string.IsNullOrWhiteSpace(NewKoi.Breed) ||
                    string.IsNullOrWhiteSpace(NewKoi.Origin))
                {
                  
                    return Page();
                }

                // Thêm mới Koi vào database
                int newKoiId = await _koiService.AddKoi(NewKoi);
                if (newKoiId <= 0)
                {
                    ModelState.AddModelError(string.Empty, "Failed to add Koi. Please try again.");
                    return Page();
                }

                // Chuẩn bị dữ liệu cho GrowthKoi
                NewGrowthKoi.KoiId = newKoiId;
                NewGrowthKoi.Size = double.TryParse(Request.Form["Size"], out double size) ? size : 0;
                NewGrowthKoi.Weight = double.TryParse(Request.Form["Weight"], out double weight) ? weight : 0;
                NewGrowthKoi.BodyShape = Request.Form["Body"].ToString();
                NewGrowthKoi.Age = int.TryParse(Request.Form["Age"], out int age) ? age : 0;
                NewGrowthKoi.Price = double.TryParse(Request.Form["Price"], out double price) ? price : 0;

                // Kiểm tra hình ảnh được upload
                var koiImage = Request.Form.Files["Img"];
                if (koiImage != null && koiImage.Length > 0)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var fileExtension = Path.GetExtension(koiImage.FileName).ToLower();
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                       
                        return Page();
                    }

                    // Lưu file vào thư mục "wwwroot/img/koi"
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

                    // Gán đường dẫn tương đối để sử dụng trong ứng dụng
                    NewGrowthKoi.Image = $"/img/koi/{uniqueFileName}";
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Please upload an image file.");
                    return Page();
                }


                // Kiểm tra các trường Size và Weight
                if (NewGrowthKoi.Size == 0 || NewGrowthKoi.Weight == 0)
                {
                    ModelState.AddModelError(string.Empty, "Size and Weight are required.");
                    return Page();
                }

                // Thêm mới GrowthKoi vào database
                bool isGrowthKoiAdded = await _growthKoiService.AddGrowthKoi(NewGrowthKoi);
                if (!isGrowthKoiAdded)
                {
                    ModelState.AddModelError(string.Empty, "Failed to add Growth information. Please try again.");
                    return Page();
                }

               
                return RedirectToPage(); // Redirect đến chính trang hiện tại hoặc trang khác nếu cần
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred: " + ex.Message);
                return Page();
            }
        }
    }
}
