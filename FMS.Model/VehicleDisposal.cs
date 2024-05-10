using System;

namespace FMS.Model
{
    public  class VehicleDisposal
    {
        public int Id { get; set; }

        public int? VehicleId { get; set; }

        public DateTime? Date { get; set; }


        public string Value { get; set; }


        public string Referance { get; set; }

 
        public string DisposalUserId { get; set; }

        public string CODReport { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
