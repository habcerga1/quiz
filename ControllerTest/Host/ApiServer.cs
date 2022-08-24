using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace ControllerTest.Host;

class ApiServer : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        // shared extra set up goes here
        return base.CreateHost(builder);
    }
}