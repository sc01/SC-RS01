namespace Sign.Models.Business
{
    public class AttachmentForBigManger
    {
        public int Id { get; set; }
        public byte[] ImagesBytes { get; set; }

        public int BigMangerId { get; set; }
        public BigManger BigManger { get; set; }
    }
}
