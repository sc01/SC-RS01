using System;

namespace Sign.Models.Business
{
   public class ReportModelViews
    {
        public int Id { get; set; }

        public string Statement { get; set; }

        public DateTime DateTime { get; set; }

        public string PaperType { get; set; }

        public decimal PriceDecimal { get; set; }
    }
}
