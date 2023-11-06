namespace EmployeeMangementSystem.Common;
public static class ServiceConfigurations
{
    internal static string MyAllowSpecificsOrigins
    {
        get
        {
            return "_myAllowSpecificsOrigins";
        }
    }

    //cors origin allowed setup....
    internal static bool IsOriginAllowed(string host, string curentEnv, string devEnvName, string stgEnvName, string proEnvName)
    {
        string[]? crosOriginAllowed = null;

        if (curentEnv.Equals(devEnvName,
            StringComparison.InvariantCultureIgnoreCase))
        {
            crosOriginAllowed = new[]
            {
                "app-ofh-frontend-dev.ofhwebsite.net"
            };
        }
        else if (curentEnv.Equals(stgEnvName,
            StringComparison.InvariantCultureIgnoreCase))
        {
            crosOriginAllowed = new[]
            {
                "app-ofh-frontend-staging.ofhwebsite.net"
            };
        }
        else if (curentEnv.Equals(proEnvName, StringComparison.InvariantCultureIgnoreCase))
        {
            crosOriginAllowed = new[]
            {
                "app-ofh-frontend-prod.ofhwebsite.net"
            };
        }
        else
        {
            crosOriginAllowed = new[]
            {
                "locallhost:4200"
            };
        }
        return crosOriginAllowed.Any(origin => Regex.IsMatch(host, $@"^http(s)?://.*{origin}(:[0-9]+)?$", RegexOptions.IgnoreCase));
    }
}
