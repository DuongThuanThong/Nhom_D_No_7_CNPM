using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages
{
    public class MyPond : PageModel
    {
        private readonly ILogger<MyPond> _logger;

        public MyPond(ILogger<MyPond> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}