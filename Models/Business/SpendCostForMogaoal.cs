namespace Sign.Models.Business
{
    public class SpendCostForMogaoal
    {
        public int Id { get; set; }
        public string Statment { get; set; }
        public int CostCenterid { get; set; }
        public double Price { get; set; }
        public int MogalolSpendid { get; set; }
        public string BillNumber { get; set; }
        public double Total { get; set; }
        public MogalolSpend MogalolSpend { get; set; }
    }
}
