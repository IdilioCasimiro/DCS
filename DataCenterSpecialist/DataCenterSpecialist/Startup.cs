using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataCenterSpecialist.Startup))]
namespace DataCenterSpecialist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
