using System.Web;
using System.Web.Mvc;

namespace AspMvcAuthenticationWithAwsCognito
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
