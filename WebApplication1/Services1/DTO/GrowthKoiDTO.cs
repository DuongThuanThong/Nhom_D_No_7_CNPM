using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1.DTO
{
    public class GrowthKoiDTO
    {
        public int GrowthId { get; set; }

        public int? KoiId { get; set; }

        public string? Image { get; set; }

        public double? Size { get; set; }

        public double? Weight { get; set; }

        public string? BodyShape { get; set; }

        public int? Age { get; set; }

        public double? Price { get; set; }

        public DateOnly? GrowDate { get; set; }
    }
}
