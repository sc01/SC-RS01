namespace Sign.Models.Business
{
  public  class ImagesRepo
    {
        public int Id { get; set; }
        public string NameOfImage { get; set; }

        public byte[] ImageBytes { get; set; }
    }
}
