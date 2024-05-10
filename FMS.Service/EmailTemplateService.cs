
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;
using System;

namespace FMS.Service
{
    public class EmailTemplateService : IEmailTemplateService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public EmailTemplateService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region CRUD Methods
        public void Create(EmailTemplate emailTemplate)
        { 
            unitOfWork.EmailTemplateRepository.Add(emailTemplate);
        }

        public void Delete(EmailTemplate emailTemplate)
        {
            unitOfWork.EmailTemplateRepository.Delete(emailTemplate);
        }

        public void Update(EmailTemplate emailTemplate)
        {
            unitOfWork.EmailTemplateRepository.Update(emailTemplate);
        }

        public int Save()
        {
            return unitOfWork.Commit();
        }
                          
        #endregion

        #region Get Methods
        public IEnumerable<EmailTemplate> GetAll()
        {
            return unitOfWork.EmailTemplateRepository.GetAll().OrderByDescending(m => m.Id);
        }

        public EmailTemplate GetById(int id)
        {
            return GetAll().FirstOrDefault(m => m.Id == id);

        }

        #endregion
    }
}
