using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenMonday.Core.MondayDriver.Interfaces;
using OpenMonday.Core.MondayDriver.InternalServices.Interfaces;
using OpenMonday.Core.MondayDriver.Services;
using OpenMonday.Core.MondayDriver.Services.Interfaces;

public static class ServiceCollectionExtensions
{
    private const string MONDAYHTTPCLIENTNAME = "MONDAY";

    public static IServiceCollection AddOpenMondayServices(this IServiceCollection services)
    {
        services.AddHttpClient(MONDAYHTTPCLIENTNAME, (sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<OpenMondayDriverOptions>>().Value;

            client.BaseAddress = new Uri(options.MondayWebApiUrl); // /v2
            client.DefaultRequestHeaders.Add("Authorization", options.MondayToken);
        });

        // Add Monday Client
        services.AddMondayClient().ConfigureHttpClient((sp, client) =>
          {
              var factory = sp.GetRequiredService<IHttpClientFactory>();
              var mondayClient = factory.CreateClient(MONDAYHTTPCLIENTNAME);

              client.BaseAddress = mondayClient.BaseAddress;

              foreach (var header in mondayClient.DefaultRequestHeaders)
                  client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
          });

        // Register file http service
        services.AddHttpClient<IMondayFileClientService, MondayFileClientService>(MONDAYHTTPCLIENTNAME);

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