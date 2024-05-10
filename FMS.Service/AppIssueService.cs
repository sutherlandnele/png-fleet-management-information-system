
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;


namespace FMS.Service
{
    public class AppIssueService : IAppIssueService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public AppIssueService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region CRUD Methods
        public void Create(AppIssue appIssue)
        { 
            unitOfWork.AppIssueRepository.Add(appIssue);
        }

        public void Delete(AppIssue appIssue)
        {
            unitOfWork.AppIssueRepository.Delete(appIssue);
        }

        public void Update(AppIssue appIssue)
        {
            unitOfWork.AppIssueRepository.Update(appIssue);
        }

        public int Save()
        {
            return unitOfWork.Commit();
        }



        #endregion

        #region Get Methods
        public IEnumerable<AppIssue> GetAll()
        {
            return unitOfWork.AppIssueRepository.GetAll().OrderByDescending(m => m.Id);
        }

        public AppIssue GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }


        #endregion
    }
}
