using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(mmmPizza.MoreJeeps.Startup))]

namespace mmmPizza.MoreJeeps;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSingleton<IGameRepository, GameRepository>();
        builder.Services.AddScoped<IGameService, GameService>();

        builder.Services.AddOptions<MoreJeepsTableSettings>()
            .Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.GetSection("MoreJeepsTableSettings").Bind(settings);
            });
    }
}
