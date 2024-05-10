namespace FMS.Model
{
    using System;


    public class Operator
    {
        public int Id { get; set; }

        public int? OperatorTypeId { get; set; }

        public int? BusinessGroupId { get; set; }

 
        public string DriverName { get; set; }


        public string LicenseNumber { get; set; }


        public string LicenseClass { get; set; }

        public DateTime? LicenseExpiry { get; set; }

        public DateTime? permiteIssueDate { get; set; }


        public string StaffNumber { get; set; }

        public int? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

   
        public string Designation { get; set; }

 
        public string PermiteNumber { get; set; }

        public int? CenterId { get; set; }

        public int? ContactDetailId { get; set; }

        public bool? IsCustodian { get; set; }

        public virtual BusinessGroup BusinessGroup { get; set; }

        public virtual Center Center { get; set; }

        public virtual ContactDetail ContactDetail { get; set; }

        public virtual SystemParameter SystemParameter { get; set; }

        public virtual SystemParameter SystemParameter1 { get; set; }
    }
}
