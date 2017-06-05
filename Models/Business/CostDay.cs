using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sign.Models.Business
{
    public class CostDay
    {

        [Display(Name = "رقــم الورقـــة")]
        public int Id { get; set; }

        [Display(Name = "التــاريخ")]
        public DateTime DateTime { get; set; }

        [Display(Name = "ملاحظــــــات")]
        public string NoteforEngMogem { get; set; }

        public string SigforEngmogem { get; set; }

       
        public bool AuditAgree { get; set; }
        [Display(Name = "ملاحظــــــات")]
        public string AuditNote { get; set; }
        public string AuditSig { get; set; }


        public int ProjectMangerAccept { get; set; }
        [Display(Name = "ملاحظــــــات")]
        public string NoteforProjectManger { get; set; }
        public string SigforProjectManger { get; set; }


        public bool AccbigAccaptable { get; set; }
        [Display(Name = "ملاحظــــــات")]
        public string AccbigNote { get; set; }
        public string AccbigSig { get; set; }


        public bool AuditManger { get; set; }
        [Display(Name = "ملاحظــــــات")]
        public string AuditmangNote { get; set; }
        public string AuditmangSig { get; set; }


        public bool EvpAccept { get; set; }
        [Display(Name = "ملاحظــــــات")]
        public string EvpNote { get; set; }
        public string EvpSig { get; set; }


        public int AGreeAble { get; set; }
        [Display(Name = "ملاحظــــــات")]
        public string Noted { get; set; }
        public string CeoSig { get; set; }

        

        public int PaymentMethod { get; set; }
        [Display(Name = "رقــم الشيــــك")]
        public string ChequeNumber { get; set; }

        public Bank Bank { get; set; }
        [Display(Name = "البنـــك")]
        public int BankId { get; set; }

        [Display(Name = "رقــم الحــساب")]
        public string BankNumb { get; set; }

        [Display(Name = "ملاحظــــــات")]
        public string BoxNote { get; set; }

        [Display(Name = "المجـــموع")]
        public double Total { get; set; }

        public string BoxSig { get; set; }
        public string ChequePic { get; set; }
        public string FirstStatment { get; set; }

        public List<ScForCostDay> ScForCostDays { get; set; } = new List<ScForCostDay>();

        public List<CostDayAttachment> CostDayAttachments { get; set; } = new List<CostDayAttachment>();


    }
}
