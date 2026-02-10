using Microsoft.Extensions.DependencyInjection;
using OpenMonday.Core.MondayDriver.Interfaces;
using OpenMonday.Core.MondayDriver.InternalServices.Interfaces;
using OpenMonday.Core.MondayDriver.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOpenMondayServices(this IServiceCollection services, Func<OpenMondayDriverOptions> configureOptions)
    {
        if (configureOptions == null)
        {
            throw new ArgumentNullException(nameof(configureOptions));
        }

        services.AddHttpClient("Monday", (sp, client) =>
        {
             var options = configureOptions.Invoke();

             client.BaseAddress = new Uri(options.MondayWebApiUrl); // /v2
             client.DefaultRequestHeaders.Add("Authorization", options.MondayToken);
         });

        // Add Monday Client
        services.AddMondayClient().ConfigureHttpClient((sp, client) =>
          {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var mondayClient = factory.CreateClient("Monday");

            client.BaseAddress = mondayClient.BaseAddress;

            foreach (var header in mondayClient.DefaultRequestHeaders)
                client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
          });

        // Register custom service
        services.AddScoped<IMondayDriverBoardStructureConverterService, MondayDriverBoardStructureConverterService>();
        services.AddScoped<IMondayDriverBoardItemsConverterService, MondayDriverBoardItemsConverterService>();
        services.AddScoped<IMondayBoardDriverService, MondayBoardDriverService>();

        services.AddScoped<IMondayDriverTeamConverterService, MondayDriverTeamConverterService>();
        services.AddScoped<IMondayTeamDriverService, MondayTeamDriverService>();

        services.AddScoped<IMondayDriverUserConverterService, MondayDriverUserConverterService>();
        services.AddScoped<IMondayUserDriverService, MondayUserDriverService>();

        services.AddScoped<IBoardBuilder, BoardBuilders>();
        services.AddScoped<IBoardItemBuilder, BoardItemBuilder>();
        services.AddScoped<IBoardStructureBuilder, BoardStructureBuilder>();

        services.AddScoped<IBoardServices, BoardServices>();

        return services;
    }

    public class OpenMondayDriverOptions
    {
        public string? MondayWebApiUrl { get; set; }
        public string? MondayToken { get; set; }
        public string? MondayFileEndpoint { get; set; }
    }
}