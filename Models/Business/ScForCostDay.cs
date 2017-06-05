namespace Sign.Models.Business
{
    public class ScForCostDay
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int CostCenterid { get; set; }
        public string StateMent { get; set; }
        public string BillNumber { get; set; }
        public int CostDayId { get; set; }
        public CostDay CostDay { get; set; }
    }
}
