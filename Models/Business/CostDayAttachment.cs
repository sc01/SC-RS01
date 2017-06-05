namespace Sign.Models.Business
{
    public class CostDayAttachment
    {
        public int Id { get; set; }
        public string PicId { get; set; }
        public int CostDayId { get; set; }
        public CostDay ProjectMangment { get; set; }
    }
}
