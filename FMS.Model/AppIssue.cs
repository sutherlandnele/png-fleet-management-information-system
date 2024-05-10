using System;

namespace FMS.Model
{

    public class AppIssue
    {
        public int Id { get; set; }

        public int? AppIssueTypeId { get; set; }

        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? HasBeenResolved { get; set; }

        public virtual SystemParameter AppIssueType { get; set; }
    }
}
