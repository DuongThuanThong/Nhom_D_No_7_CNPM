using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages.product
{
    public class Medikoi : PageModel
    {
        private readonly ILogger<Medikoi> _logger;

        public Medikoi(ILogger<Medikoi> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}