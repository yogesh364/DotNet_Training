﻿using System.Web;
using System.Web.Mvc;

namespace Web_Api_DB_First
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
