using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeControl.Startup))]
namespace EmployeeControl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
