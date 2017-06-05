namespace Sign.Models.Business
{
    public class AttachmentForMogaoal
    {
        public int Id { get; set; }
        public byte[] ImagesBytes { get; set; }

        public int MogalolSpendid { get; set; }

        public MogalolSpend MogalolSpend { get; set; }
    }
}
