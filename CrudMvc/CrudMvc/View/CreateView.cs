using System.IO;
using System.Web.Mvc;

namespace CrudMvc.View
{
    public class CreateView : IView
    {
        #region Implementation of IView

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            var model = viewContext.RouteData;
        }

        #endregion
    }
}
