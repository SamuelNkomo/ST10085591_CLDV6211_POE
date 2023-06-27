using System.Web;
using System.Web.Mvc;

namespace ST10085591_CLDV6211_POE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
