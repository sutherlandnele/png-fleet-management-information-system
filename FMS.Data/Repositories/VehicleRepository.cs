using FMS.Model;
using FMS.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using FMS.Common;
using System.Text;

namespace FMS.Data.Repositories
{
    internal class VehicleRepository: RepositoryBase<Vehicle>, IVehicleRepository
    {
        #region Constant String
        private const String VEHICLEREGISTERATIONEXPIRAY = "Vehicle Registration Expiry";
        private const String VEHICLESAFETYSTICKEREXPIRY = "Vehicle Safety Sticker Expiry";
        private const String VEHICLETHIRDPARTYINSURANCEEXPIRY = "Vehicle Third Party Insurance Expiry";
        private const String VEHICLESCHEDULESERVICEDUENOTICE = "Vehicle Schedule Service Due Notice";

        private const String BUSINESSGROUP = "BusinessGroup";
        private const String CENTER = "Center";
        private const String CONTACTDETAIL = "ContactDetail";
        private const String MODEL = "Model";
        private const String FINANCIALSTATUS = "FinancialStatus";
        private const String FUELUSAGECATEGORY = "FuelUsageCategory";
        private const String MAKE = "Make";
        private const String FUELTYPE = "FuelType";
        private const String TRANSMISSION = "Transmission";
        private const String STATUS = "Status";
        private const String CONDITION = "Condition";
        private const String NEXTSERVICE = "NextService";
        private const String LASTSERVICE = "LastService";
        private const String NEXTSERVICETYPE = "NextServiceType";
        private const String USAGESTATUS = "UsageStatus";
        private const String VEHICLETYPE = "VehicleType";
        private const String COMPLIANCES = "Compliances";
        private const String SCHEDULESERVICES = "ScheduleServices";
        private const String SERVICES = "Services";
        private const String FUELVOUCHERS = "FuelVouchers";
        private const String INCIDENTS = "Incidents";
        private const String VEHICLEALLOCATIONS = "VehicleAllocations";
        private const String VEHICLEDISPOSALS = "VehicleDisposals";
        private const String VEHICLEREFUELS = "VehicleRefuels";
        private const String VEHICLETRANSFERS = "VehicleTransfers";

        #endregion
        internal VehicleRepository(IDbFactory dbFactory): base(dbFactory) {

        }
        #region Get Methods

        public IEnumerable<Vehicle> GetAll(string assetNumber, string registrationNumber, int unitNumber, int groupNumber, int centerNumber)
        {
            IEnumerable<Vehicle> result = GetAll().OrderByDescending(x => x.Id);

            if (!string.IsNullOrEmpty(assetNumber))
            {
                result = result.Where(x => x.AssetNumber != null && x.AssetNumber.ToUpper().Contains(assetNumber.ToUpper()));
            }
            if (!string.IsNullOrEmpty(registrationNumber))
            {
                result = result.Where(x => x.RegistrationNumber != null && x.RegistrationNumber.ToUpper().Contains(registrationNumber.ToUpper()));
            }
            if (unitNumber != -1)
            {
                result = result.Where(x => x.BusinessGroup != null && x.BusinessGroup.BusinessUnitId != null && x.BusinessGroup.BusinessUnitId == unitNumber);
            }
            if (groupNumber != -1)
            {
                result = result.Where(x => x.BusinessGroup != null && x.BusinessGroup.GroupNumber == groupNumber);
            }
            if (centerNumber != -1)
            {
                result = result.Where(x => x.Center != null && x.CenterId == centerNumber);
            }
            return result;
        }

        public IEnumerable<Vehicle> GetAllVehiclesAscending()
        {
            int disposeStatus = (int)Parameters.VehicleFinancialStatus.Disposed;

            return GetAll().Where(x => x.StatusId != disposeStatus).OrderBy(x => x.RegistrationNumber);
        }
                
        public IEnumerable<Vehicle> GetVehicleListByRegisterationRenewl()
        {
            return GetAll().Where(x => x.RegistrationExpiry.HasValue && x.RegistrationExpiry.Value != DateTime.MinValue && (x.RegistrationExpiry.Value.Subtract(DateTime.Now.Date)).Days <= 30);

        }
        

        #endregion

   
    }

}
