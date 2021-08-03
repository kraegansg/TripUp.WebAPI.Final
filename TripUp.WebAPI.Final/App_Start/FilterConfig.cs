using System.Web;
using System.Web.Mvc;

namespace TripUp.WebAPI.Final
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
