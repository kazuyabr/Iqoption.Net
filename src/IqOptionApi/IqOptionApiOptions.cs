using System;
using Serilog;

namespace IqOptionApi {
    public class IqOptionApiOptions : IIqOptionApiOptions {

        private readonly IqOptionConfiguration Configuration = new IqOptionConfiguration();
        public static IIqOptionApiOptions New => new IqOptionApiOptions();
        
        public IIqOptionApiOptions UseEmailAddress(string emailAddress) {
            Configuration.Email = emailAddress;
            return this;
        }

        public IIqOptionApiOptions UsePassword(string password) {
            Configuration.Password = password;
            return this;
        }

        public IIqOptionApiOptions UseExternalEndPoints(string endPoints) {
            Configuration.Host = endPoints;
            return this;
        }

        public IIqOptionApiOptions UseLogger(ILogger logger) {
            IqOptionLoggerFactory.SetLogger(logger);
            return this;
        }


        public Lazy<IIqOptionApi> CreateNewInstance() {

            return new Lazy<IIqOptionApi>(() => {
                    var api = new IqOptionApi(Configuration.Email, Configuration.Password, Configuration.Host);

                    api.ConnectAsync().ConfigureAwait(false);
                    return api;
                }
            );
        }
    }
}