using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinylVault.Models
{
    public class Record
    {
        public int Id { get; set; }
        [Required]
        public string Artist { get; set; } = string.Empty;
        [Required]
        public string Album { get; set; } = string.Empty;
        [Required]
        public int Year { get; set; }
    }
}
