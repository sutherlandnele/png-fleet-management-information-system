
using System;
using System.Collections.Generic;
using System.Linq;
using FMS.Model;

namespace FMS.Service
{
    public interface IDashboardService
    {
        #region Get methods
        IEnumerable<Dashboard> GetAll();
        String Path(String role);
        object GetFuelUsage(List<int> CenterIds);
        object GetTop10FuelConsumers(List<int> CenterIds);
        object GetChartData(IGrouping<string, VehicleRefuel> deployd);
        object GetVehicleStatus(List<int> CenterIds);
        #endregion

        #region CRUD Methods

        #endregion


    }
}
