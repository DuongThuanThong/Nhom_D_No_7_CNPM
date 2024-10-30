using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages.menu
{
    public class Pondproducts : PageModel
    {
        private readonly ILogger<Pondproducts> _logger;

        public Pondproducts(ILogger<Pondproducts> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}