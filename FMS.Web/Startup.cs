using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FMS.Web.Startup))]

namespace FMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);

            // *** Important, need to wire up SignalR after the Owin Identity configruation (above code) or else SignalR Authentication & Authorization will not work as expected
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR(new HubConfiguration
            {
                EnableDetailedErrors = true,
                EnableJSONP = true
            });
        }
        
    }
}
