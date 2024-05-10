namespace FMS.Model
{
    using System;

    public class SqlAudit
    {
        public int Id { get; set; }

        public DateTime? DateAndTime { get; set; }

 
        public string Username { get; set; }


        public string Role { get; set; }

    
        public string ComputerName { get; set; }

   
        public string SubSystem { get; set; }

   
        public string DatabaseTable { get; set; }


        public string DatabaseAction { get; set; }

     
        public string SqlStatement { get; set; }
    }
}
