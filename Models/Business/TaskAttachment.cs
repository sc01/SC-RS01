namespace Sign.Models.Business
{
 public class TaskAttachment
    {
        public int Id { get; set; }
        public byte [] ImagesBytes { get; set; }
     public TaskTables TaskTable { get; set; }
    }
}
