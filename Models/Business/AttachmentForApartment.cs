namespace Sign.Models.Business
{
    public class AttachmentForApartment
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public Apartment Apartment { get; set; }
     
    }
}
