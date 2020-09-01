using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(RCTrans.Web.Areas.Identity.IdentityHostingStartup))]

namespace RCTrans.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            _ = builder.ConfigureServices((context, services) =>
                {
                });
        }
    }
}
