using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages.product
{
    public class Kusuri : PageModel
    {
        private readonly ILogger<Kusuri> _logger;

        public Kusuri(ILogger<Kusuri> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}