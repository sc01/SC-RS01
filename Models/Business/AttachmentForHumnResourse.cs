namespace Sign.Models.Business
{
    public class AttachmentForHumnResourse
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int HumenResourseid { get; set; }

        public ProjectMangment ProjectMangment { get; set; }
    }
}
