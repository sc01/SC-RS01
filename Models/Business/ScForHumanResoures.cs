namespace Sign.Models.Business
{
    public class ScForHumanResoures
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int CostCenterid { get; set; }

        public string StateMent { get; set; }

        public int HumenResourseid { get; set; }
        
        public string BillNumber { get; set; }
        public HumenResourse HumenResourse { get; set; }

    }
}
