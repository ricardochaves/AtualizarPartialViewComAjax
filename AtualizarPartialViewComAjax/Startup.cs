using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AtualizarPartialViewComAjax.Startup))]
namespace AtualizarPartialViewComAjax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
