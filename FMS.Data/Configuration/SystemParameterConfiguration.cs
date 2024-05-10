using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class SystemParameterConfiguration : EntityTypeConfiguration<SystemParameter>
    {
        public SystemParameterConfiguration()
        {
            ToTable("MstSystemParameters");


            HasKey<int>(k => k.Id);


            Property(e => e.ParameterName)
            .HasMaxLength(250)
            .IsUnicode(false);


            HasMany(e => e.Compliances)
            .WithOptional(e => e.SystemParameter)
            .HasForeignKey<int?>(e => e.ComplianceType);


            HasMany(e => e.ContactDetails)
            .WithOptional(e => e.SystemParameter)
            .HasForeignKey<int?>(e => e.Contacttype);


            HasMany(e => e.ContactDetails1)
            .WithOptional(e => e.SystemParameter1)
            .HasForeignKey<int?>(e => e.SupplierType);


            HasMany(e => e.ContactDetails2)
            .WithOptional(e => e.SystemParameter2)
            .HasForeignKey<int?>(e => e.Gender);

            HasMany(e => e.DepotTanks)
            .WithOptional(e => e.SystemParameter)
            .HasForeignKey<int?>(e => e.FuelTypeId);


            HasMany(e => e.FuelVouchers)
            .WithOptional(e => e.SystemParameter)
            .HasForeignKey<int?>(e => e.FueltypeId);


            HasMany(e => e.Incidents)
            .WithOptional(e => e.SystemParameter)
            .HasForeignKey<int?>(e => e.IncidentStatusId);


            HasMany(e => e.Incidents1)
            .WithOptional(e => e.SystemParameter1)
            .HasForeignKey<int?>(e => e.IncidentTypeId);


            HasMany(e => e.Incidents2)
            .WithOptional(e => e.SystemParameter2)
            .HasForeignKey<int?>(e => e.IncidentStatusId);


            HasMany(e => e.Models)
            .WithOptional(e => e.SystemParameter)
            .HasForeignKey<int?>(e => e.MakeId);


            HasMany(e => e.Operators)
            .WithOptional(e => e.SystemParameter)
            .HasForeignKey<int?>(e => e.OperatorTypeId);


            HasMany(e => e.Operators1)
            .WithOptional(e => e.SystemParameter1)
            .HasForeignKey<int?>(e => e.Gender);


            HasMany(e => e.ScheduleServices)
            .WithOptional(e => e.SystemParameter)
            .HasForeignKey<int?>(e => e.ScheduleServiceTypeId);


            HasMany(e => e.Services)
            .WithOptional(e => e.SystemParameter)
            .HasForeignKey<int?>(e => e.ServiceTypeId);


            HasMany(e => e.Services1)
            .WithOptional(e => e.SystemParameter1)
            .HasForeignKey<int?>(e => e.ScheduleServiceTypeId);


            HasMany(e => e.VehicleRefuels)
            .WithOptional(e => e.SystemParameter)
            .HasForeignKey<int?>(e => e.FuelUsageCategoryId);


            HasMany(e => e.Notifications)
            .WithOptional(e => e.SystemParameter)
            .HasForeignKey<int?>(e => e.NotificationTypeId);


            HasMany(e => e.Notifications1)
            .WithOptional(e => e.SystemParameter1)
            .HasForeignKey<int?>(e => e.WhenAppearId);


            HasMany(e => e.Notifications2)
            .WithOptional(e => e.SystemParameter2)
            .HasForeignKey<int?>(e => e.SeverityId);


            HasMany(e => e.Alerts)
            .WithOptional(e => e.MstSystemParameter)
            .HasForeignKey<int?>(e => e.AlertTypeId);

            HasMany(e => e.AppIssues)
            .WithOptional(e => e.AppIssueType)
            .HasForeignKey<int?>(e => e.AppIssueTypeId);

            HasMany(e => e.VehicleFinancialStatuses)
            .WithOptional(e => e.FinancialStatus)
            .HasForeignKey<int?>(e => e.FinancialStatusId);


            HasMany(e => e.VehicleFuelUsageCategories)
            .WithOptional(e => e.FuelUsageCategory)
            .HasForeignKey<int?>(e => e.FuelUsageCategoryId);


            HasMany(e => e.VehicleMakes)
            .WithOptional(e => e.Make)
            .HasForeignKey<int?>(e => e.MadeId);


            HasMany(e => e.VehicleFuelTypes)
            .WithOptional(e => e.FuelType)
            .HasForeignKey<int?>(e => e.FuelTypeId);


            HasMany(e => e.VehicleTransmissions)
            .WithOptional(e => e.Transmission)
            .HasForeignKey<int?>(e => e.TransmissionId);


            HasMany(e => e.VehicleStatuses)
            .WithOptional(e => e.Status)
            .HasForeignKey<int?>(e => e.StatusId);


            HasMany(e => e.VehicleConditions)
            .WithOptional(e => e.Condition)
            .HasForeignKey(e => e.ConditionId);


            HasMany(e => e.VehicleNextServices)
            .WithOptional(e => e.NextService)
            .HasForeignKey<int?>(e => e.NextServiceId);


            HasMany(e => e.VehicleLastServices)
            .WithOptional(e => e.LastService)
            .HasForeignKey<int?>(e => e.LastServiceId);


            HasMany(e => e.VehicleNextServiceTypes)
            .WithOptional(e => e.NextServiceType)
            .HasForeignKey<int?>(e => e.NextServiceTypeId);


            HasMany(e => e.VehicleUsageStatuses)
            .WithOptional(e => e.UsageStatus)
            .HasForeignKey<int?>(e => e.UsageStatusId);

            HasMany(e => e.VehicleInsuranceTypes)
            .WithOptional(e => e.InsuranceType)
            .HasForeignKey<int?>(e => e.InsuranceTypeId);

            HasMany(e => e.VehicleAcquisitionTypes)
            .WithOptional(e => e.AcquisitionType)
            .HasForeignKey<int?>(e => e.AcquisitionTypeId);


            HasMany(e => e.VehicleRefuels1)
            .WithOptional(e => e.SystemParameter1)
            .HasForeignKey<int?>(e => e.FuelTypeId);

        }

    }
}
