
using System.Collections.Generic;
using FMS.Model;



namespace FMS.Service
{
    public interface IVehicleManagementService
    {
        #region Get Methods

        IEnumerable<Vehicle> GetVehicleRegistrationExpiryByCenterPermission(string userName);
        IEnumerable<Vehicle> GetVehicleSafetyStickerExpiryByCenterPermission(string userName);

        IEnumerable<Vehicle> GetAll();
        IEnumerable<Vehicle> GetFilterByCenterPermission(string userName, string assetNumber, string registrationNumber, int unitNumber, int groupNumber, int centerNumber);

        IEnumerable<Vehicle> GetFilterByCenterPermissionBOS(string userName, string assetNumber, string registrationNumber, int unitNumber, int groupNumber, int centerNumber);

        IEnumerable<Vehicle> GetFilterByCenterPermission(string userName);
        IEnumerable<Vehicle> GetDisposedVehicles(string userName, string assetNumber, string registrationNumber, int unitNumber, int groupNumber, int centerNumber);
        IEnumerable<Vehicle> GetUnallocatedVehicles(string currentUser, int registrationNumber);
        IEnumerable<Vehicle> GetVehiclelist(string userName);
        IEnumerable<Vehicle> SearchVehicle(string regNumber, string userName);
        IEnumerable<Vehicle> GetAllVehiclesAscending();
        IEnumerable<Vehicle> GetAll(string assetNumber, string registrationNumber, int unitNumber, int groupNumber, int centerNumber);
        IEnumerable<Vehicle> GetVehicleListByRegisterationRenewl();
        IEnumerable<Vehicle> GetVehicleListBySafetyStickerRenewl();
        Vehicle GetVehicleById(int id);
        string GetVehicleCustodianDriver(int id);
        string GetVehicleRegion(int id);
        string GetVehicleBusinessUnit(int id);
        decimal? GetTotalFuelConsumptionCostToDate(int id);
        decimal? GetTotalServiceCostToDate(int id);
        bool IsInUse(int id);

        #endregion

        #region CRUD Methods
        void Create(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(Vehicle vehicle);       
        int Save();
        #endregion


    }
}
