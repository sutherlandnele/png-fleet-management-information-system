
using System.Collections.Generic;
using FMS.Model;
using FMS.Data.Infrastructure;
using System.Linq;
using FMS.Common;

namespace FMS.Service
{
    public class NotificationService : INotificationService
    {
        #region private readonly fields
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public NotificationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region CRUD Methods
        public void Create(Notification notification)
        {
            unitOfWork.NotificationRepository.Add(notification);
        }

        public void Delete(Notification notification)
        {
            unitOfWork.NotificationRepository.Delete(notification);
        }

        public void Update(Notification notification)
        {
            unitOfWork.NotificationRepository.Update(notification);
        }

        public int Save()
        {
            return unitOfWork.Commit();
        }

        #endregion

        #region Get Methods

        public IEnumerable<Notification> GetAll()
        {
            return unitOfWork.NotificationRepository.GetAll().OrderByDescending(m => m.Id);
        }

        public IEnumerable<Notification> GetAll(int type, int whenAppear, int severity, int emailTemplate)
        {
            var result = GetAll();

            if (type > 0)
            {
                result = result.Where(x => x.NotificationTypeId == type);
            }
            if (whenAppear > 0)
            {
                result = result.Where(x => x.WhenAppearId == whenAppear);
            }
            if (severity > 0)
            {
                result = result.Where(x => x.SeverityId == severity);
            }
            if (emailTemplate > 0)
            {
                result = result.Where(x => x.EmailTemplateId == emailTemplate);
            }
            return result;
        }

        public Notification GetNotificationById(int id)
        {
            if (id > 0)
            {
                var notification = GetAll().FirstOrDefault(x => x.Id == id);

                if (notification != null)
                {
                    return notification;
                }
            }
            return new Notification { Id = -1 };
        }

        public int GetNotificationWeek(string notificationtype)
        {
            var listNotification = GetAll();

            int whenappear = 0;

            var notifications = listNotification.Where(x => x.SystemParameter.ParameterName == notificationtype);

            foreach (Notification notification in notifications)
            {
                if (notification.SystemParameter1.ParameterName == "1 Week" && whenappear < 1)
                {
                    whenappear = 1;
                }
                if (notification.SystemParameter1.ParameterName == "2 Weeks" && whenappear < 2)
                {
                    whenappear = 2;
                }
                if (notification.SystemParameter1.ParameterName == "3 Weeks" && whenappear < 3)
                {
                    whenappear = 3;
                }
            }
            return whenappear;
        }

        #endregion
    }
}
