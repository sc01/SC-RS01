using System;
using System.Collections.Generic;

namespace Sign.Models.Business
{
    public class MogalolSpend
    {

        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public double Prev { get; set; }
        public double Current { get; set; }
        public double Total { get; set; }
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public string Payment { get; set; }

        public string CintractNote { get; set; }

        public string PhoneNumber { get; set; }

        public double ContractPrice { get; set; }

        public string NoteforEngMogem { get; set; }
        public string NoteforProjectManger { get; set; }

        public string SigforEngmogem { get; set; }

        public int ProjectMangerAccept { get; set; }

        public string SigforProjectManger { get; set; }

        public bool AuditAgree { get; set; }

        public string AuditNote { get; set; }
        public string AuditSig { get; set; }
        public bool AuditBigAccounterAccaptable { get; set; }

        public bool AuditManger { get; set; }
        public string AccbigNote { get; set; }

        public string AccbigSig { get; set; }

        public string AccmangNote { get; set; }
        public string AccmangSig { get; set; }
        public int AGreeAble { get; set; }
        

        public string EvpSig { get; set; }

        public bool EvpAccept { get; set; }

        public string EvpNote { get; set; }

        public string Noted { get; set; }

        public string CeoSig { get; set; }

        public int PaymentMethod { get; set; }

        public string ChequeNumber { get; set; }

        public string BankNumb { get; set; }
        public string BoxNote { get; set; }

        public string BoxSig { get; set; }

        public byte[] CheqCopyBytes { get; set; }

      
        public string FirstStatment { get; set; }
        public List<SpendCostForMogaoal> SpendCostForMogaoals { get; set; } = new List<SpendCostForMogaoal>();

        public List<AttachmentForMogaoal> AttachmentForMogaoals { get; set; } = new List<AttachmentForMogaoal>();

    }
}
