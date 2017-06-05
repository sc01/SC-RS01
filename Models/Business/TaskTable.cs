using System;
using System.Collections.Generic;

namespace Sign.Models.Business
{
   public class TaskTables
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserAndAuthratoreId { get; set; }
        public int IdOfCreater { get; set; }

        public bool TaskType { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }

        public int Scope { get; set; }

        public string Decriptions { get; set; }

        public bool DateTimeType { get; set; }

        public string DateTimeVaule { get; set; }
        public string ResonForTime { get; set; }

        public List<TaskAttachment> TaskAttachments { get; set; } = new List<TaskAttachment>();

        public string RejectedTaskReson { get; set; }

        //why this task take awihle
        public string EndedTaskReson { get; set; }

        public decimal Stars { get; set; }

        public string UserWhoStarsThis { get; set; }

        public string Noted { get; set; }

       public DateTime From { get; set; }

        public DateTime To { get; set; }

        //1 for done 2 for clanceld 
       public int TaskStatus { get; set; }

        public int Level { get; set; }

    }
}
