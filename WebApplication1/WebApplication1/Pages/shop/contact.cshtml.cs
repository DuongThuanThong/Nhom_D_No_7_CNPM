using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages
{
    public class contact : PageModel
    {
        private readonly ILogger<contact> _logger;

        public contact(ILogger<contact> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}