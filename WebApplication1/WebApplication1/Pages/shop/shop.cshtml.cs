using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages.shop
{
    public class shop : PageModel
    {
        private readonly ILogger<shop> _logger;

        public shop(ILogger<shop> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}