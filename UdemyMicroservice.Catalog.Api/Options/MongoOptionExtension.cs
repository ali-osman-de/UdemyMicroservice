using Microsoft.Extensions.Options;

namespace UdemyMicroservice.Catalog.Api.Options;

public static class MongoOptionExtension
{
    public static IServiceCollection AddMongoOptionServiceExtension(this IServiceCollection services) {

        services.AddOptions<MongoOption>().BindConfiguration(nameof(MongoOption)).ValidateDataAnnotations().ValidateOnStart();

        services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoOption>>().Value);

        return services;
    }
}
