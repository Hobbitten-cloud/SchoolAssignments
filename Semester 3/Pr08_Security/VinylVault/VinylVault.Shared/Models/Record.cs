using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinylVault.Shared.Models
{
    public class Record
    {
        public int Id { get; set; }
        [Required]
        public string Artist { get; set; } = string.Empty;
        [Required]
        public string Album { get; set; } = string.Empty;
        [Required]
        [Range(1, 2025)]
        public int Year { get; set; }

    }
}
