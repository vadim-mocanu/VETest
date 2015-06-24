using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VETest.Startup))]
namespace VETest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
