using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Hackathon.Manager.Api.Infra.Utils;

public class UserPoolUtils
{
    public static string UserPoolId = "";
    public static string UserPoolClientId = "";

    public static async Task SetValues(IConfiguration configuration)
    {
        var poolName = configuration["Aws:PoolName"] ?? throw new InvalidOperationException("Aws PoolName not found!");
        Console.WriteLine(poolName);
        using (var provider = new AmazonCognitoIdentityProviderClient(RegionEndpoint.USEast1))
        {
            UserPoolId = (await provider.ListUserPoolsAsync(new ListUserPoolsRequest()))
                .UserPools.FirstOrDefault(x => x.Name == poolName)?.Id ?? throw new InvalidOperationException("User pool id not found!");

            UserPoolClientId = (await provider.ListUserPoolClientsAsync(new ListUserPoolClientsRequest { UserPoolId = UserPoolId }))
                .UserPoolClients.FirstOrDefault()?.ClientId ?? throw new InvalidOperationException("User pool client id not found!");
        }
    }
}