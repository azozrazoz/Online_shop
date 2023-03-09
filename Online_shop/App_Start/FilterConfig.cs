using Online_shop.Filters;
using System.Web;
using System.Web.Mvc;

namespace Online_shop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // filters.Add(new AuthorizationFilter());
        }
    }
}
