using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages
{
    public class Food : PageModel
    {
        private readonly ILogger<Food> _logger;

        public Food(ILogger<Food> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}