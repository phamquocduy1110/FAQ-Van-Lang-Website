using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dieubanthuonghoi.Startup))]
namespace dieubanthuonghoi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
