using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VMSCORE;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Class1.addnew();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var name = TextBox1.Text;
        int birtDate = Convert.ToInt32(TextBox2.Text);
        WSREF.WS ws = new WSREF.WS();
        Label1.Text = ws.CalculateMyAge(birtDate, name);

    }
}