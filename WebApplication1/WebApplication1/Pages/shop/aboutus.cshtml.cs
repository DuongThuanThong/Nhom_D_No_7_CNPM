using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages
{
    public class aboutus : PageModel
    {
        private readonly ILogger<aboutus> _logger;

        public aboutus(ILogger<aboutus> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}