using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class yonetmenListele : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_yonetmenler.DataSource = vrktmn.yonetmenListele();
            lv_yonetmenler.DataBind();
        }

        protected void lv_yonetmenler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idYonetmen = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {

                vrktmn.yonetmenSil(idYonetmen);
            }
            lv_yonetmenler.DataSource = vrktmn.yonetmenListele();
            lv_yonetmenler.DataBind();

        }

    }
}
