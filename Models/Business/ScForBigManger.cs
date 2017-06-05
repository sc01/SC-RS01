namespace Sign.Models.Business
{
    public class ScForBigManger
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public int CostCenterid { get; set; }

        public string StateMent { get; set; }

        public string BillNumber { get; set; }
        public int BigMangerId { get; set; }
        public BigManger BigManger { get; set; }
    }
}
