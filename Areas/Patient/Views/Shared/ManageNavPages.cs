using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace testing.Areas.Patient.Views.Shared 
{ 
    public static class ManageNavPages
    {
        public static string Medcard => "Medcard";

        public static string History => "History";

        public static string MedcardNavClass(ViewContext viewContext) => PageNavClass(viewContext, Medcard);

        public static string HistoryNav(ViewContext viewContext) => PageNavClass(viewContext, History);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
