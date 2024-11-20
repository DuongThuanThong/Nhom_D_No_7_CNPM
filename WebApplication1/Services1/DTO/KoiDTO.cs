using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services1.DTO
{
    public class KoiDTO
    {
        public int KoiId { get; set; }

        public string Name { get; set; } = null!;

        public int? Gender { get; set; }

        public string? Breed { get; set; }

        public string? Origin { get; set; }

        public int? PondId { get; set; }

        public int? UserId { get; set; }


    }
}
