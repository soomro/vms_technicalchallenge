using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using System.Reflection;

namespace Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class GridUtil
    {
        Control row = null;

        public static Control GetControl(Control row, string id)
        {
            return row.FindControl(id);
        }

        public static void SetControlText(Control row, string tboxId, string value)
        {
            TextBox tbox = (row.FindControl(tboxId) as TextBox);
            if (tbox != null)
            {
                tbox.Text = value;
            }
        }

        public GridUtil(Control row)
        {
            this.row = row;
        }

        public void SetControlText(string cntId, string val)
        {
            SetControlText(cntId, val, val.Length);
        }

        public void SetControlText(string cntId, DateTime val)
        {
            SetControlText(cntId, val.ToString("d MMMM yyyy"));
        }

        public void SetControlText(string cntId, string val, int len)
        {
            Control cnt = row.FindControl(cntId);
            if (cnt == null)
            {
                return;
            }


            PropertyInfo pi = cnt.GetType().GetProperty("Text");
            PropertyInfo piTitle = cnt.GetType().GetProperty("Title");
            PropertyInfo piTooltip = cnt.GetType().GetProperty("ToolTip");
            if (pi != null)
            {
                if (val.Length > len)
                {
                    pi.SetValue(cnt, val.Substring(0, len) + "..", null);
                    if (piTooltip != null)
                    {
                        piTooltip.SetValue(cnt, val, null);
                    }
                    if (piTitle != null)
                    {
                        piTitle.SetValue(cnt, val, null);
                    }
                }
                else
                {
                    pi.SetValue(cnt, val, null);
                }

            }

        }

        public Control GetControl(string id)
        {
            return row.FindControl(id);
        }

        #region Style Methods

        /// <SUMMARY>
        /// This method creates a tooltip for the header columns in a datagrid.  
        /// Note:  This should only be used when the grid has sorting enabled.
        /// </SUMMARY>
        /// <PARAM name="e">DataGridItemEventArgs</PARAM>
        public void
           SetHeaderToolTip(System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            // Is the item type of type header?
            if (e.Row.RowType == DataControlRowType.Header)
            {
                string headerText = "";
                // Add the onmouseover and onmouseout
                // attribute to each header item.
                foreach (TableCell cell in e.Row.Cells)
                {
                    try
                    {
                        LinkButton lb = (LinkButton)cell.Controls[0];
                        headerText = "";

                        if (lb != null)
                        {
                            headerText = lb.Text;
                        }

                        lb.ToolTip = "Sort By " + lb.Text;
                    }
                    catch { }
                }
            }
        }

        /// <SUMMARY>
        /// This method changes the color of the row when the mouse is over it.
        /// Note: You must have a class called gridHover
        ///       that sets the color of the hover row.
        /// </SUMMARY>
        /// <PARAM name="dg">DataGrid</PARAM>
        /// <PARAM name="e">DataGridItemEventArgs</PARAM>
        public void SetRowHover(GridView dg,
            System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                string className = "";

                // Is the item an item or alternating item?
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // Is the itemtype of type item?
                    if (e.Row.RowState == DataControlRowState.Normal)
                    {
                        className = dg.RowStyle.CssClass;
                    }
                    else if (e.Row.RowState == DataControlRowState.Alternate)
                    {
                        className = dg.AlternatingRowStyle.CssClass;

                    }

                    e.Row.Attributes.Add("onmouseover",
                             "this.className='gridHover';");
                    e.Row.Attributes.Add("onmouseout",
                             "this.className='" + className + "';");
                }
            }
            catch
            {
            }
        }
        // public void SetRowHover(DataGrid dg,
        //System.Web.UI.WebControls.DataGridItemEventArgs e)
        // {
        //     try
        //     {
        //         string className = "";
        //         // Create reference to grid...
        //         DataGrid tempDG = (DataGrid)sender;

        //         // Is the item an item or alternating item?
        //         if ((e.Item.ItemType == ListItemType.Item) ||
        //             (e.Item.ItemType == ListItemType.AlternatingItem))
        //         {
        //             // Is the itemtype of type item?
        //             if (e.Item.ItemType == ListItemType.Item)
        //             {
        //                 // replace dg with tempDG
        //                 //className = dg.ItemStyle.CssClass;
        //                 className = tempDG.ItemStyle.CssClass;
        //             }
        //             else if (e.Item.ItemType == ListItemType.AlternatingItem)
        //             {
        //                 //and here...
        //                 //className = dg.AlternatingItemStyle.CssClass;
        //                 className = tempDG.AlternatingItemStyle.CssClass;
        //             }// The rest of the method is unedited..
        //         }
        //     }
        // }

        /// <SUMMARY>
        /// This method sets the CssStyle for a link button
        /// contained in the datagrid item, alternatingitem,
        /// or edititem row.  
        /// </SUMMARY>
        /// <PARAM name="e">DataGridItemEventArgs</PARAM>
        public void
          SetGridLinkButtonStyle(System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow )
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    try
                    {
                        LinkButton lb = (LinkButton)cell.Controls[0];

                        if (lb != null)
                        {
                            lb.CssClass = "GridLink";
                        }
                    }
                    catch { }
                }
            }
        }

        #endregion
    }

    /// <summary>
    /// Iki şekilde kullanılabilir. Temel olarak bir gridstyleutil objesi gerekli parametrelerle oluşturulması gerekli. 
    /// Bu pageload da yapılabildigi gibi, sayfalarımızın inherit ettigi pagebase de onprerender methodunda da yapılıyor.
    /// Nasıl?: onprerender methodu sayfadaki tüm gridviewları recursive olarak buluyor. ve 
    /// GridStyleUtil gi = new GridStyleUtil(GridView1,GridStyleEnum.xxx) şeklinde style giydirme işlemi yapılıyor.
    /// 
    /// style lar http://icant.co.uk/csstablegallery/ adresinden alınmadır. 
    /// </summary>
    public class GridStyleUtil
    {
        GridView gv;
        GridStyleEnum style;
        public GridStyleUtil(GridView gv, GridStyleEnum style)
        {
            this.gv = gv;
            this.style = style;
            ApplyStyling();
        }

        private void ApplyStyling()
        {
            // include correct styleshhet
            string includeTemplate =
                "<link rel='stylesheet' text='text/css' href='{0}' />";
            string includeLocation = "";
            switch (style)
            {
                case GridStyleEnum.Undefined:
                    break;
                case GridStyleEnum.MaviSari:
                    includeLocation = gv.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Utils.GridStyles.Grid_MaviSari.css");
                    break;
                case GridStyleEnum.YesilSari:
                    includeLocation = gv.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Utils.GridStyles.Grid_YesilSari.css");
                    break;
                case GridStyleEnum.MaviYesil:
                    includeLocation = gv.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Utils.GridStyles.Grid_MaviYesil.css");
                    break;
                case GridStyleEnum.CilginKirmizi:
                    includeLocation = gv.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Utils.GridStyles.Grid_CilginKirmizi.css");
                    break;
                case GridStyleEnum.TableSpirit:
                    includeLocation = gv.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Utils.GridStyles.Grid_TableSpirit.css");
                    break;
                case GridStyleEnum.OrangeYouGlad:
                    includeLocation = gv.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Utils.GridStyles.Grid_OrangeYouGlad.css");
                    break;
                case GridStyleEnum.Niko:
                    includeLocation = gv.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Utils.GridStyles.Grid_Niko.css");
                    break;
                default:
                    break;
            }
            LiteralControl include =
                  new LiteralControl(String.Format(includeTemplate, includeLocation));
            ((System.Web.UI.HtmlControls.HtmlHead)gv.Page.Header).Controls.Add(include);

            //wear grid
            gv.AlternatingRowStyle.CssClass = "AltRow";
            gv.RowStyle.CssClass = "NormalRow";
            gv.CssClass = "Grid";

            gv.RowStyle.Reset();
            gv.AlternatingRowStyle.Reset();
            gv.HeaderStyle.Reset();
            gv.BorderStyle = BorderStyle.NotSet;
            gv.EditRowStyle.Reset();
            gv.FooterStyle.Reset();
            gv.SelectedRowStyle.Reset();
            gv.Style.Clear();
            gv.BackColor = System.Drawing.Color.Empty;


        }

    }

    public enum GridStyleEnum
    {
        Undefined = 0,
        MaviSari = 1,
        YesilSari = 2,
        MaviYesil = 3,
        CilginKirmizi = 4,
        TableSpirit = 5,
        OrangeYouGlad = 6,
        Niko = 7
    }
}
