using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ESMM.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Display(Name = "İl")]
        public string Name { get; set; }
        public int State { get; set; } = 0;
    }
}
