using Amazon.CognitoIdentityProvider;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspMvcAuthenticationWithAwsCognito
{
    public class CognitoUser : IdentityUser
    {
        public string Password { get; set; }
        public UserStatusType Status { get; set; }

        //public string Roles { get; set; }
    }
}