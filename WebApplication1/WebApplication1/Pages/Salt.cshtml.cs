using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages
{
    public class Salt : PageModel
    {
        private readonly ILogger<Salt> _logger;

        public Salt(ILogger<Salt> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}