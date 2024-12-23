using Microsoft.Extensions.DependencyInjection;
using OpenMonday.Core.MondayDriver.Interfaces;
using OpenMonday.Core.MondayDriver.InternalServices.Interfaces;
using OpenMonday.Core.MondayDriver.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOpenMondayServices(this IServiceCollection services, Action<OpenMondayDriverOptions> configureOptions)
    {
        if (configureOptions == null)
        {
            throw new ArgumentNullException(nameof(configureOptions));
        }

        var options = new OpenMondayDriverOptions();
        configureOptions(options);

        if (options.MondayWebApiUrl == null)
        {
            throw new ArgumentNullException("MondayWebApiUrl must be not null");
        }

        // Add Monday Client
        services.AddMondayClient()
          .ConfigureHttpClient(client =>
          {
              client.BaseAddress = new Uri(options.MondayWebApiUrl);
              client.DefaultRequestHeaders.Add("Authorization", options.MondayToken);
          }
          );

        // Register custom service
        services.AddScoped<IMondayDriverBoardStructureConverterService, MondayDriverBoardStructureConverterService>();
        services.AddScoped<IMondayDriverBoardItemsConverterService, MondayDriverBoardItemsConverterService>();
        services.AddScoped<IMondayBoardDriverService, MondayBoardDriverService>();
        
        services.AddScoped<IMondayDriverTeamConverterService, MondayDriverTeamConverterService>();
        services.AddScoped<IMondayTeamDriverService, MondayTeamDriverService>();

        services.AddScoped<IBoardBuilder, BoardBuilders>();
        services.AddScoped<IBoardItemBuilder, BoardItemBuilder>();

        services.AddScoped<IBoardServices, BoardServices>();

        return services;
    }

    public class OpenMondayDriverOptions
    {
        public string? MondayWebApiUrl { get; set; }
        public string? MondayToken { get; set; }
    }
}