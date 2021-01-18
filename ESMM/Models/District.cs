using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ESMM.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        [Column("city_id")]
        [ForeignKey("City")]
        public int CityId { get; set; }
        [MaxLength(50)]
        [Display(Name = "İlçe")]
        public string Name { get; set; }
        [Column("mernis_code")]
        public int MernisCode { get; set; } = 0;
        public int State { get; set; } = 0;
    }
}
