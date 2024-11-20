using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1.DTO
{
    public class PondDTO
    {
        public int PondId { get; set; }
        public string? Name { get; set; }
        public double? Size { get; set; }
        public double? PumpCapacity { get; set; }
        public double? DrainCount { get; set; }
        public double? Volume { get; set; }
        public double? Depth { get; set; }
        public string? Image { get; set; }
        public int? UserId { get; set; }
    }
}
