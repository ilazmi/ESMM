using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ESMM.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Type { get; set; }
        [MaxLength(50)]
        [Display(Name = "Adı")]
        public string Name { get; set; }
        [MaxLength(50)]
        [Display(Name = "Soyadı")]
        public string Surname { get; set; }
        [Column("company_title")]
        [Display(Name = "Ünvanı")]
        public string CompanyTitle{ get; set; }
        [Column("tax_office")]
        [Display(Name = "Vergi Dairesi")]
        public string TaxOffice{ get; set; }
        [Column("tax_number")]
        [Display(Name = "Vergi No")]
        public string TaxNumber{ get; set; }
        [Display(Name = "Adres")]
        public string Address{ get; set; }
        [Column("city_id")]
        public int? CityId{ get; set; }
        public City City{ get; set; }
        [Column("district_id")]
        public int? DistrictId{ get; set; }
        public District District { get; set; }
        [Display(Name = "GSM No")]
        public string GSM { get; set; }
        [Display(Name = "Telefon No")]
        public string Phone { get; set; }
        [Display(Name = "Faks No")]
        public string Fax { get; set; }
        [Display(Name = "E-Posta")]
        public string EMail { get; set; }
        [Display(Name = "Not")]
        public string Comment { get; set; }
        public int State { get; set; }

        [NotMapped]
        public List<City> Cities { get; set; }
        [NotMapped]
        public List<District> Districts { get; set; }
    }
}
