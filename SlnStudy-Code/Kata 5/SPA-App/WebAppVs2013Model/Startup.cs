using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppVs2013Model.Startup))]
namespace WebAppVs2013Model
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
