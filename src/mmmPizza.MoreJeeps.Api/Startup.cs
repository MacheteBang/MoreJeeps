using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(mmmPizza.MoreJeeps.Startup))]

namespace mmmPizza.MoreJeeps;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {

    }
}
