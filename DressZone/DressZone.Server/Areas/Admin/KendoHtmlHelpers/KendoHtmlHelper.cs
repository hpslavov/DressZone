namespace DressZone.Server.Areas.Admin.KendoHtmlHelpers
{
    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;
    using System.Web.Mvc;
    public static class KendoHtmlHelper
    {
        public static GridBuilder<T> AdminGrid<T>(this HtmlHelper helper, string name) where T : class
        {
            return helper.Kendo().Grid<T>()
                .Name(name)
                .Pageable()
                .Sortable()
                .Filterable(filter => filter.Mode(GridFilterMode.Menu))
                .Editable(edit => edit.Mode(GridEditMode.PopUp));
        }
    }
}