namespace Sign.Models.Business
{
    public class AttachmentForProjectMangment
    {
        public int Id { get; set; }
        public byte[] ImagesBytes { get; set; }

        public int ProjectMangmentid { get; set; }
        public ProjectMangment ProjectMangment { get; set; }
    }
}
