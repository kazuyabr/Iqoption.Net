using Serilog;

namespace IqOptionApi {
    public interface IIqOptionApiOptions {

        IIqOptionApiOptions UseEmailAddress(string emailAddress);
        IIqOptionApiOptions UsePassword(string password);
        IIqOptionApiOptions UseExternalEndPoints(string endPoints);
        IIqOptionApiOptions UseLogger(ILogger logger);

    }
}