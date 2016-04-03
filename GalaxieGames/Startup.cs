using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GalaxieGames.Startup))]
namespace GalaxieGames
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
