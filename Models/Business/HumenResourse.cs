using System;
using System.Collections.Generic;

namespace Sign.Models.Business
{
    public class HumenResourse
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        //change for humenResoureses
        public string NoteforAccSalry { get; set; }
        public string NoteforhumenManger { get; set; }

        public string SigforforAccSalry { get; set; }

        public string SigforhumenManger { get; set; }

        public bool AuditAgree { get; set; }

        public string AuditNote { get; set; }
        public string AuditSig { get; set; }
        public string AccbigNote { get; set; }

        public string AccbigSig { get; set; }

        public string AccmangNote { get; set; }
        public string AccmangSig { get; set; }

        public int AGreeAble { get; set; }

        public string EvpNote { get; set; }

        public string EvpSig { get; set; }

        public string CeoNote { get; set; }

        public string CeoSig { get; set; }

        public int ExeMon { get; set; }

        public string ChequeNumber { get; set; }

        public int Bankid { get; set; }
        public string BoxNote { get; set; }

        public string BoxSig { get; set; }

        public List<SCforProjectMangent> SCforProjectMangents { get; set; }

        public List<AttachmentForProjectMangment> AttachmentForProjectMangments { get; set; }

    }
}
