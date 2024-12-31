
using System.Text.RegularExpressions;

namespace UniversityManagementSystem.UI.Constraints
{
    public class TestConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(values.ContainsKey(routeKey))
            {
                string? str=Convert.ToString(values[routeKey]);
                if (str != null) 
                {
                    Regex reg = new Regex("^(jan|apr|jul|oct)$");
                    if(reg.IsMatch(str))
                        return true;
                }
            }
            return false;
        }
    }
}
