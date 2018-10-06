using System;
using Microsoft.Extensions.DependencyInjection;

namespace IqOptionApi.DependencyInjection {

    public static class IqOptionApiServiceProviderExtensions {
        public static IServiceCollection AddIqOption(this IServiceCollection services,
            Action<IIqOptionApiOptions> configureOptions) {

            var options = (IqOptionApiOptions) IqOptionApiOptions.New;
            configureOptions(options);

            services.AddSingleton(options.CreateNewInstance().Value);
            return services;
        }
    }
}


