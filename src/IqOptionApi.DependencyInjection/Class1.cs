namespace IqOptionApi.DependencyInjection
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Extensions.DependencyInjection;

    namespace IqOptionApi.DependencyInjection.Extensions
    {
        public static class IqOptionApiServiceProviderExtensions
        {
            public static IServiceCollection AddIqOption(this IServiceCollection services, Action<IIqOptionApiOptions> configureOptions)
            {

                var options = (IqOptionApiOptions)IqOptionApiOptions.New;
                configureOptions(options);

                services.AddSingleton(options.CreateNewInstance());
                return services;
            }


            //to use
            public static void Use()
            {

                IServiceCollection services = default(IServiceCollection);

                services.AddIqOption(cfg =>
                    cfg
                        .UseEmailAddress("")
                        .UsePassword("")
                        .UseExternalEndPoints("")
                );
            }
        }
    }

}
