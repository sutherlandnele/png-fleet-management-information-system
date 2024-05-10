
using System;
using System.Collections.Generic;
using FMS.Model;

namespace FMS.Service
{
    public interface IEmailTemplateService
    {
        #region Get methods
        IEnumerable<EmailTemplate> GetAll();
        EmailTemplate GetById(int id);

        #endregion

        #region CRUD Methods
        void Create(EmailTemplate emailTemplate);
        void Update(EmailTemplate emailTemplate);
        void Delete(EmailTemplate emailTemplate);
        int Save();
        #endregion
     

    }
}
