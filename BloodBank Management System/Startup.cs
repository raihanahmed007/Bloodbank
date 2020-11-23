using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BloodBank_Management_System.Startup))]
namespace BloodBank_Management_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
