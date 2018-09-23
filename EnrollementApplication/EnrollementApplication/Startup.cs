using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnrollementApplication.Startup))]
namespace EnrollementApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
