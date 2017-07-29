using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Sign.Models.Business
{
    public class Contract
    {
      
        public long Id { get; set; }
        [Display(Name = "نـــــوع الـــعـــقــد")]
        public string ContractType { get; set; }
        [Column(TypeName = "date")]
        [Display(Name = "تـــاريـــخ الــعــقــد")]
        public DateTime ContractDate { get; set; }
        [Display(Name = "مـكـان إبرام العـقـد")]
        public string ContractPlace { get; set; }
        [Column(TypeName ="date" )]
        [Display(Name = "تـاريخ بـداية العــقـد")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        [Display(Name = "تـاريـخ نـهاية العـقـد")]
        public DateTime EndDate { get; set; }
        [Display(Name = "بيـانات الـمـسـتأجـر")]
        public long CustomerId { get; set; }
        [Display(Name = "بـيـانـات المـسـتـأجـر")]
        public Customer CustomerName  { get; set; }
        [Display(Name = "اجـمالي قـيمة العـقد")]
        public decimal TotoalContratValue { get; set; }
        [Display(Name = "فــاتـورة الـكـهـرباء")]
        public decimal ElectricBillValue { get; set; }
        [Display(Name = "فــاتـــورة الــمــيـاه")]
        public decimal WaterBillValue { get; set; }
        [Display(Name = "مـــبــلــغ الــتـامـيـن")]
        public decimal InsuranceValue { get; set; }
        [Display(Name = "فــــتـــرة الـــعــقــد")]
        public string PeriodType { get; set; }
        [Display(Name = "مــبــلـغ الــســعـي")]
        public decimal OfficeFees { get; set; }
        [Display(Name = "بـيـانات الـشــقــة")]
        public Apartment ApartmentDetils { get; set; }
    }
}
