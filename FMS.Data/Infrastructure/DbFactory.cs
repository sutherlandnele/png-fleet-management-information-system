using System;


namespace FMS.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private FMSEntities _appDbContext;
        public FMSEntities Init()
        {
            return _appDbContext ?? (_appDbContext = new FMSEntities());
        }


        protected override void DisposeCore()
        {
            if (_appDbContext != null)
                _appDbContext.Dispose();
        }
    }
}
