namespace Sign.Models.Business
{
    public class SCforProjectMangent
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public int CostCenterid { get; set; }

        public string StateMent { get; set; }

        public string BillNumber { get; set; }
        
        public int ProjectMangmentid { get; set; }
        public ProjectMangment ProjectMangment { get; set; }

    }
}
