using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirstProject__Elias
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
