using System;


namespace FMS.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        FMSEntities Init();
    }
}
