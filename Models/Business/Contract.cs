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
        public string ContractType { get; set; }
        [Column(TypeName = "date")]
        [Display(Name = "تـاريـخ العـقـد")]
        public DateTime ContractDate { get; set; }
        [Display(Name = "مـكـان إبرام العـقـد")]
        public string ContractPlace { get; set; }
        [Column(TypeName ="date" )]
        [Display(Name = "تـاريخ بـداية العـقد")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        [Display(Name = "تـاريـخ نـهاية العـقـد")]
        public DateTime EndDate { get; set; }
        [Display(Name = "الـمـسـتـأجـر")]
        public long CustomerId { get; set; }
        public Customer CustomerName  { get; set; }
        [Display(Name = "اجـمالي قـيمة العـقد")]
        public decimal TotoalContratValue { get; set; }
        [Display(Name = "فاتورة الكهرباء")]
        public decimal ElectricBillValue { get; set; }
        [Display(Name = "فاتورة المياه")]
        public decimal WaterBillValue { get; set; }
        [Display(Name = "مبلغ التامين")]
        public decimal InsuranceValue { get; set; }
        [Display(Name = "فترة العقد")]
        public string PeriodType { get; set; }
        [Display(Name = "مبلغ السعي")]
        public decimal OfficeFees { get; set; }
        [Display(Name = "بيانات الشـقـة")]
        public Apartment ApartmentDetils { get; set; }
    }
}
