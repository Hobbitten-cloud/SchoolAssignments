using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinylVault.Shared.DTOs
{
    public class RecordCreateDto
    {
        [Required(ErrorMessage = "Du skal angive en kunstner.")]
        public string Artist { get; set; } = string.Empty;
        [Required(ErrorMessage = "Du skal angive et album.")]
        public string Album { get; set; } = string.Empty;
        [Required]
        [Range(1, 2025, ErrorMessage = "Året skal være mellem 1 og 2025.")]
        public int Year { get; set; }
    }
}
