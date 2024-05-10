
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;

namespace FMS.Service
{
    public class DashboardService : IDashboardService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public DashboardService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region CRUD Methods

        #endregion

        #region Get Methods  

        public IEnumerable<Dashboard> GetAll()
        {
            return unitOfWork.DashboardRepository.GetAll().OrderByDescending(m => m.ID);
        }

        public object GetChartData(IGrouping<string, VehicleRefuel> deployDailyGroup)
        {
            int currentYear = DateTime.Today.Year;
            int currentMonth = DateTime.Today.Month;
          
            object chart = new { X = deployDailyGroup.FirstOrDefault().RegistrationNumber, Y = deployDailyGroup.Where(x => x.Date.Value.Month == currentMonth).Sum(x => x.Liters) };

            return chart;
        }

        public object GetFuelUsage(List<int> CenterIds)
        {
            int currentYear = DateTime.Today.Year;
            int currentMonth = DateTime.Today.Month;

            var query = from m in unitOfWork.VehicleRefuelRepository.GetAll()                            
                        where ((m.Date.Value.Year == currentYear - 1 && m.Date.Value.Month >= currentMonth)
                        || (m.Date.Value.Year == currentYear && m.Date.Value.Month <= currentMonth) && CenterIds.Contains(m.CenterId.Value))
                        group m by new { m.Date.Value.Year, m.Date.Value.Month } into g
                        select
                        new
                        {
                            Date = g.FirstOrDefault().Date,
                            Litres = g.Sum(p => p.Liters)
                            //CenterId = g.FirstOrDefault().CenterId,
                        };

            query = query.OrderBy(x => x.Date);

            var data = query.ToList();

            return data;

        }

        public object GetTop10FuelConsumers(List<int> CenterIds)
        {
            int currentYear = DateTime.Today.Year;
            int currentMonth = DateTime.Today.Month;

            var result = (from depotDaily in unitOfWork.VehicleRefuelRepository.GetAll()
                           .Where(x => x.Date != null && CenterIds.Contains(x.CenterId.Value)).OrderByDescending(x => x.Liters).ToList()
                           where (depotDaily.Date.Value.Month == currentMonth && depotDaily.Date.Value.Year == currentYear)
                           group depotDaily by depotDaily.RegistrationNumber into g 
                           select GetChartData(g)).Take(10);
            return result;
        }

        public object GetVehicleStatus(List<int> CenterIds)
        {
            var selectedVehicles = unitOfWork.VehicleRepository.GetAll().Where(x => x.CenterId!=null && CenterIds.Contains(x.CenterId.Value));
            int financial = Convert.ToInt32(Parameters.SystemParameterType.VehicleFinancialStatus);
            int operational = Convert.ToInt32(Parameters.SystemParameterType.VehicleOperationStatus);
            int usage = Convert.ToInt32(Parameters.SystemParameterType.VehicleUsageStatus);

            var finData = from systemData in unitOfWork.SystemParameterRepository.GetAll().Where(x => x.ParameterCodeId == financial)
                          select new
                          {
                              Status = systemData.ParameterName,
                              Count = selectedVehicles.Count(x => x.FinancialStatusId == systemData.Id)
                          };

            var operData = from systemData in unitOfWork.SystemParameterRepository.GetAll().Where(x => x.ParameterCodeId == operational)
                           select new
                           {
                               Status = systemData.ParameterName,
                               Count = selectedVehicles.Count(x => x.StatusId == systemData.Id)
                           };

            var usgData = from systemData in unitOfWork.SystemParameterRepository.GetAll().Where(x => x.ParameterCodeId == usage)
                          select new
                          {
                              Status = systemData.ParameterName,
                              Count = selectedVehicles.Count(x => x.UsageStatusId == systemData.Id)
                          };

            var data = finData.ToList();

            data.AddRange(operData);
            data.AddRange(usgData);


            return data;
        }

        public string Path(string role)
        {
            return GetAll().FirstOrDefault(x => x.Role == role).Role;
        }

        #endregion
    }
}
