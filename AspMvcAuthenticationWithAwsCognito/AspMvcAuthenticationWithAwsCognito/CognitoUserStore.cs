using System;
using System.Configuration;
using System.Threading.Tasks;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Microsoft.AspNet.Identity;

namespace AspMvcAuthenticationWithAwsCognito
{
    public interface ICongnitoStore : IUserStore<CognitoUser>
    {

    }

    public class CognitoUserStore : ICongnitoStore


    {
        private readonly AmazonCognitoIdentityProviderClient _client =
            new AmazonCognitoIdentityProviderClient();
        private readonly string _clientId = ConfigurationManager.AppSettings["CLIENT_ID"];
        private readonly string _poolId = ConfigurationManager.AppSettings["USERPOOL_ID"];

        public Task CreateAsync(CognitoUser user)
        {
            // Register the user using Cognito
            var signUpRequest = new SignUpRequest
            {
                ClientId = ConfigurationManager.AppSettings["CLIENT_ID"],
                Password = user.Password,
                Username = user.Email,

            };

            var emailAttribute = new AttributeType
            {
                Name = "email",
                Value = user.Email
            };
            signUpRequest.UserAttributes.Add(emailAttribute);


            _client.SignUpAsync(signUpRequest);
            _client.AdminConfirmSignUp(new AdminConfirmSignUpRequest { Username = user.Email, UserPoolId = _poolId });

            return Task.CompletedTask;
        }

        public void AddUsertoGroup(string username, string groupname)
        {
            try
            {
                var addUserToGroup = new AdminAddUserToGroupRequest { GroupName = groupname, Username = username, UserPoolId = _poolId };
                _client.AdminAddUserToGroup(new AdminAddUserToGroupRequest());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task DeleteAsync(CognitoUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<CognitoUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<CognitoUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CognitoUser user)
        {
            throw new NotImplementedException();
        }


    }
}