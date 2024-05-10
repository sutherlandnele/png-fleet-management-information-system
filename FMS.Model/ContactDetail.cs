namespace FMS.Model
{
    using System;
    using System.Collections.Generic;


    public class ContactDetail
    {

        public int Id { get; set; }


        public string ContactName { get; set; }

        public int? Contacttype { get; set; }

  
        public string ContactPerson { get; set; }

  
        public string PostalAddress { get; set; }

        public string StreetAddress { get; set; }

        public string Facsimile { get; set; }


        public string Email { get; set; }


        public string Telephone { get; set; }


        public string Fax { get; set; }

  
        public string Website { get; set; }

        public string Mobile { get; set; }

        public string Comments { get; set; }

        public bool? IsDriver { get; set; }

        public int? SupplierType { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? Gender { get; set; }

        public string LicenceNumber { get; set; }

        public string LicanceClass { get; set; }

        public DateTime? LicenceExpiryDate { get; set; }

        public string PPLPermitNumber { get; set; }

        public int? CenterId { get; set; }

        public DateTime? PPLPermitIssueDate { get; set; }

        public virtual List<BusinessGroup> BusinessGroups { get; set; }

        public virtual List<BusinessUnit> BusinessUnits { get; set; }

        public virtual List<Center> Centers { get; set; }

        public virtual Center Center { get; set; }

        public virtual SystemParameter SystemParameter { get; set; }

        public virtual SystemParameter SystemParameter1 { get; set; }

        public virtual SystemParameter SystemParameter2 { get; set; }

        public virtual List<Incident> Incidents { get; set; }

        public virtual List<FuelVoucher> FuelVouchers { get; set; }

        public virtual List<Operator> Operators { get; set; }

        public virtual List<Regional> Regionals { get; set; }

        public virtual List<Service> Services { get; set; }

        public virtual List<Service> Services1 { get; set; }

        public virtual List<Alert> Alerts { get; set; }

        public virtual List<Vehicle> Vehicles { get; set; }

        public virtual List<VehicleAllocation> VehicleAllocations { get; set; }

        public virtual List<VehicleRefuel> VehicleRefuels { get; set; }
        public virtual List<VehicleRefuel> VehicleRefuels1 { get; set; }
    }
}
