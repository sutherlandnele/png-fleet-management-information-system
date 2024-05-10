using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FMS.Web.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;

namespace FMS.Web.Hubs
{
    public class OnlineUser
    {
        public string Name { get; set; }
        public HashSet<string> ConnectionIds { get; set; }
    }

    [Authorize]
    public class ComsHub : Hub
    {
        private readonly ILifetimeScope _hubLifetimeScope;
        private static readonly ConcurrentDictionary<string, OnlineUser> OnlineUsers = new ConcurrentDictionary<string, OnlineUser>();
        private readonly UserManager<IdentityUser, Guid> _userManager;
        private readonly RoleManager<IdentityRole, Guid> _roleManager;
        public ComsHub(ILifetimeScope hublifetimeScope)
        {
            // Create a lifetime scope for the hub.
            _hubLifetimeScope = hublifetimeScope.BeginLifetimeScope();

            // Resolve dependencies from the hub lifetime scope.
            _userManager = _hubLifetimeScope.Resolve<UserManager<IdentityUser, Guid>>();
            _roleManager = _hubLifetimeScope.Resolve<RoleManager<IdentityRole, Guid>>();

        }

        public override Task OnConnected()
        {
            string userName = Context.User.Identity.Name;

            string connectionId = Context.ConnectionId;

            var onlineUser = OnlineUsers.GetOrAdd(userName, _ => new OnlineUser
            {
                Name = userName,
                ConnectionIds = new HashSet<string>()
            });

            lock (onlineUser.ConnectionIds)
            {

                onlineUser.ConnectionIds.Add(connectionId);

                //broadcast only the first connection to all listening clients
                if (onlineUser.ConnectionIds.Count == 1)
                {
                    Clients.All.userConnected(userName);
                }
            }

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            if (stopCalled) //Graceful Disconnect
            {

                OnlineUser onlineUser;
                OnlineUsers.TryGetValue(userName, out onlineUser);

                if (onlineUser != null)
                {

                    lock (onlineUser.ConnectionIds)
                    {

                        onlineUser.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));

                        if (!onlineUser.ConnectionIds.Any())
                        {

                            OnlineUser removedUser;
                            OnlineUsers.TryRemove(userName, out removedUser);                            
                        }
                    }
                }
            }
            else  // Ungraceful disconnect. Eg. The hub server hasn't heard from the client in the last ~35 seconds.
            {

            }

            return base.OnDisconnected(stopCalled);
        }

        //return list of all active connections
        public List<string> GetAllActiveConnections()
        {
            var onlineUsers = new List<string>();
            foreach (var u in OnlineUsers)
            {
                onlineUsers.Add(u.Key);
            }

            return onlineUsers;
        }

        public void ForceLogoutUsersInRole(string roleName)
        {
            var usersInRole = (from user in _userManager.Users
                                select new
                                {
                                    Username = user.UserName,
                                    Role = (from userRole in _userManager.GetRoles(user.Id)
                                            select userRole).FirstOrDefault()
                                }).Where(m=> m.Role.Contains(roleName));

            var activeUserNames = GetAllActiveConnections();

            foreach(var activeUserName in activeUserNames)
            {
                if(usersInRole.Any(x=>x.Username.Contains(activeUserName)))
                {
                    ForceLogOut(activeUserName);
                }
            }
        }

        public void ForceLogOut(string to)
        {
            OnlineUser receiver;

            if (OnlineUsers.TryGetValue(to, out receiver))
            {
                IEnumerable<string> allReceivers;

                lock (receiver.ConnectionIds)
                {
                    allReceivers = receiver.ConnectionIds.Concat(receiver.ConnectionIds);
                }

                foreach (var cid in allReceivers)
                {
                    Clients.Client(cid).Signout();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            // Dipose the hub lifetime scope when the hub is disposed.
            if (disposing && _hubLifetimeScope != null)
            {
                _hubLifetimeScope.Dispose();
            }

            base.Dispose(disposing);
        }

    }
}