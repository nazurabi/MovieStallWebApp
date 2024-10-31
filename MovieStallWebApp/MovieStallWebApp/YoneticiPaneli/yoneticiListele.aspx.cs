using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class yoneticiListele : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_yoneticiler.DataSource = vrktmn.yoneticiListele();
            lv_yoneticiler.DataBind();
        }

        protected void lv_yoneticiler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idYonetici = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {

                vrktmn.yoneticiSil(idYonetici);
            }
            lv_yoneticiler.DataSource = vrktmn.yoneticiListele();
            lv_yoneticiler.DataBind();
        }
    }
}