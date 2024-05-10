using Microsoft.AspNet.Identity;
using System;


namespace FMS.Web.Identity
{
    public class IdentityUser : IUser<Guid>
    {
        public IdentityUser()
        {
            this.Id = Guid.NewGuid();
        }

        public IdentityUser(string userName)
            : this()
        {
            this.UserName = userName;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }      
        public string Email { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual DateTime? LastLoginTime { get; set; }
        public virtual DateTime? LockoutEndDateUtc { get; set; }
        public virtual DateTime? RegistrationDate { get; set; }
        public virtual int AccessFailedCount { get; set; }
        public virtual bool LockoutEnabled { get; set; }
    }
}