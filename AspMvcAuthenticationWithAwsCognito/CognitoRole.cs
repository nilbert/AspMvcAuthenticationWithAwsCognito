using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace AspMvcAuthenticationWithAwsCognito
{
    public class CognitoRole : IRole
    {
        public string Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}