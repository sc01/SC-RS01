using System;

namespace Sign.Models.Business
{
 public   class Cheque
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public double Amount { get; set; }
        public string Beneficiary { get; set; }
        public string Phone { get; set; }
        public string Bank { get; set; }
        public string Note { get; set; }
        public string ChequeNumber { get; set; }

        public bool ChequeStatus { get; set; }


        public bool ChequeOne { get; set; }


    }
}
