using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudMvc.View
{
    public class IndexView : IView
    {
        #region Implementation of IView

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            var models = (IEnumerable<object>)viewContext.ViewData.Model;

            HtmlTextWriter htmlWritter = new HtmlTextWriter(writer);
            var table = TableForModels(models);
            table.RenderControl(htmlWritter);
        }

        #endregion

        private Table TableForModels(IEnumerable<object> models)
        {
            Table indexTable = new Table();
            Type modelType = models.GetType().GetGenericArguments()[0];

            indexTable.Rows.Add(HeadForModelType(modelType));
            foreach (var model in models)
            {
                indexTable.Rows.Add(RowForModel(model));
            }

            return indexTable;
        }

        private TableRow HeadForModelType(Type modelType)
        {
            TableHeaderRow header = new TableHeaderRow();
            var properties = modelType.GetProperties();

            foreach (var property in properties)
            {
                TableHeaderCell th = new TableHeaderCell {Text = property.Name};
                header.Cells.Add(th);
            }

            return header;
        }

        private TableRow RowForModel(object model)
        {
            TableRow row = new TableRow();
            var properties = model.GetType().GetProperties();
            foreach (var property in properties)
            {
                TableCell cell = new TableCell { Text = property.GetValue(model, null).ToString() };
                row.Cells.Add(cell);
            }

            return row;
        }
    }
}
