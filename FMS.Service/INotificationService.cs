
using System;
using System.Collections.Generic;
using FMS.Model;

namespace FMS.Service
{
    public interface INotificationService
    {
        #region Get methods

        IEnumerable<Notification> GetAll();

        IEnumerable<Notification> GetAll(int type, int whenAppear, int severity, int emailTemplate);

        Notification GetNotificationById(int id);

        int GetNotificationWeek(string notificationtype);

        #endregion

        #region CRUD Methods
        void Create(Notification notification);
        void Update(Notification notification);
        void Delete(Notification notification);
        int Save();
        #endregion
     

    }
}
