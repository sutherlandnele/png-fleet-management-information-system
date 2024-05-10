namespace FMS.Model
{
    using System.Collections.Generic;

    public class SystemParameter
    {
        #region Fields
        public int Id { get; set; }

        public int? ParameterCodeId { get; set; }

        public string ParameterName { get; set; }

        public bool? IsHardCoded { get; set; }
        #endregion

        #region Dependent Related Objects
        public virtual SystemParameterCode SystemParameterCode { get; set; }
        #endregion

        #region Reference Related Objects
        public virtual List<Compliance> Compliances { get; set; }
        public virtual List<ContactDetail> ContactDetails { get; set; }
        public virtual List<ContactDetail> ContactDetails1 { get; set; }
        public virtual List<ContactDetail> ContactDetails2 { get; set; }
        public virtual List<DepotTank> DepotTanks { get; set; }
        public virtual List<FuelVoucher> FuelVouchers { get; set; }
        public virtual List<Incident> Incidents { get; set; }
        public virtual List<Incident> Incidents1 { get; set; }
        public virtual List<Incident> Incidents2 { get; set; }
        public virtual List<FMS.Model.Model> Models { get; set; }
        public virtual List<Operator> Operators { get; set; }
        public virtual List<Operator> Operators1 { get; set; }
        public virtual List<ScheduleService> ScheduleServices { get; set; }
        public virtual List<Service> Services { get; set; }
        public virtual List<Service> Services1 { get; set; }
        public virtual List<VehicleRefuel> VehicleRefuels { get; set; }
        public virtual List<Notification> Notifications { get; set; }
        public virtual List<Notification> Notifications1 { get; set; }
        public virtual List<Notification> Notifications2 { get; set; }
        public virtual List<Alert> Alerts { get; set; }
        public virtual List<AppIssue> AppIssues { get; set; }
        public virtual List<Vehicle> VehicleAcquisitionTypes { get; set; }
        public virtual List<Vehicle> VehicleInsuranceTypes { get; set; }
        public virtual List<Vehicle> VehicleFinancialStatuses { get; set; }
        public virtual List<Vehicle> VehicleFuelUsageCategories { get; set; }
        public virtual List<Vehicle> VehicleMakes { get; set; }
        public virtual List<Vehicle> VehicleFuelTypes { get; set; }
        public virtual List<Vehicle> VehicleTransmissions { get; set; }
        public virtual List<Vehicle> VehicleStatuses { get; set; }
        public virtual List<Vehicle> VehicleConditions { get; set; }
        public virtual List<Vehicle> VehicleNextServices { get; set; }
        public virtual List<Vehicle> VehicleLastServices { get; set; }
        public virtual List<Vehicle> VehicleNextServiceTypes { get; set; }
        public virtual List<Vehicle> VehicleUsageStatuses { get; set; }
        public virtual List<VehicleRefuel> VehicleRefuels1 { get; set; }
        #endregion
    }
}
