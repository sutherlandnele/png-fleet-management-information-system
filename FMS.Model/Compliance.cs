namespace FMS.Model
{
    using System;
   
    public class Compliance
    {
   
        public int ComplianceNumber { get; set; }

        public DateTime? ComplianceDate { get; set; }

        public DateTime? NextExpiryDate { get; set; }

        public decimal? Amount { get; set; }

        public int? RegistrationNumber { get; set; }

        public int? ComplianceType { get; set; }

        public decimal? TPIAmount { get; set; }

        public decimal? RegistrationAmount { get; set; }        
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public virtual SystemParameter SystemParameter { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
