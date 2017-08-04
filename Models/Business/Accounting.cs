using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sign.Models.Business
{
    public class Accounting
    {
        public long Id { get; set; }

        public double Crediter { get; set; }

        public double Depetor { get; set; }

        public string Deatials { get; set; }

        public string PaymentType { get; set; }

        public string ReciveAccount { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateTime { get; set; }

        public long ApartmentaIdName { get; set; }

        public long CmsId { get; set; }

        public long BulidingsId { get; set; }
        
       
    }
}
