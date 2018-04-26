using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Microsoft.AspNet.Identity;

namespace AspMvcAuthenticationWithAwsCognito
{

    public class CognitoRoleStore : IRoleStore<CognitoRole>
    {
        private readonly AmazonCognitoIdentityProviderClient _client =
            new AmazonCognitoIdentityProviderClient();
        private readonly string _clientId = ConfigurationManager.AppSettings["CLIENT_ID"];
        private readonly string _poolId = ConfigurationManager.AppSettings["USERPOOL_ID"];

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(CognitoRole role)
        {
            try
            {
                try
                {
                    var grouprequest = new CreateGroupRequest { Description = role.Description, GroupName = role.Name };
                    _client.CreateGroup(grouprequest);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CognitoRole role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CognitoRole role)
        {
            throw new NotImplementedException();
        }

        public Task<CognitoRole> FindByIdAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<CognitoRole> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}