using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for extentionMethods
/// </summary>
public static class extentionMethods
{
    public static DataTable ToDataTable<T>(this IEnumerable<T> items)
    {
        var tb = new DataTable(typeof(T).Name);

        PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in props)
        {
            tb.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }

        foreach (var item in items)
        {
            var values = new object[props.Length];
            for (var i = 0; i < props.Length; i++)
            {
                values[i] = props[i].GetValue(item, null);
            }

            tb.Rows.Add(values);
        }

        return tb;
    }
    public static void DisableLinkButton(LinkButton linkButton)
    {
        linkButton.Attributes.Remove("href");
        linkButton.Attributes.CssStyle[HtmlTextWriterStyle.Color] = "gray";
        linkButton.Attributes.CssStyle[HtmlTextWriterStyle.Cursor] = "default";
        if (linkButton.Enabled != false)
        {
            linkButton.Enabled = false;
        }

        if (linkButton.OnClientClick != null)
        {
            linkButton.OnClientClick = null;
        }
    }
}