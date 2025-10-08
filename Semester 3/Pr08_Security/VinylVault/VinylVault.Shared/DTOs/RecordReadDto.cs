using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinylVault.Shared.DTOs
{
    public class RecordReadDto
    {
        public int Id { get; set; }
        public string Artist { get; set; } = string.Empty;
        public string Album { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
