using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Hackathon.Manager.Api.Domain.Entities;
using Hackathon.Manager.Api.Domain.Interfaces.Services;
using Hackathon.Manager.Api.Infra.Utils;

namespace Hackathon.Manager.Api.Services;

public class CognitoService : ICognitoService
{
    public async Task<string> CreateUserAsync(EmployeeEntity employee, string password)
    {
        try
        {
            using (var provider = new AmazonCognitoIdentityProviderClient(RegionEndpoint.USEast1))
            {
                var signUpResult = await provider.SignUpAsync(new SignUpRequest
                {
                    ClientId = UserPoolUtils.UserPoolClientId,
                    Username = employee.Email,
                    Password = password,
                    UserAttributes = new List<AttributeType>
                    {
                        new AttributeType
                        {
                            Name = "name",
                            Value = employee.Name 
                        },
                    }
                });

                await provider.AdminConfirmSignUpAsync(new AdminConfirmSignUpRequest
                {
                    UserPoolId = UserPoolUtils.UserPoolId,
                    Username = employee.Email.ToString(),
                });

                return signUpResult.UserSub;
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message);
        }
    }
}