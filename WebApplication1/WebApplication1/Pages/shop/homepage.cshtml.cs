using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages
{
    public class homepage : PageModel
    {
        private readonly ILogger<homepage> _logger;

        public homepage(ILogger<homepage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}