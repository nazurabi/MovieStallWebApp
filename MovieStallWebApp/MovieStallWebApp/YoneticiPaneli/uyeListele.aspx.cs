using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class uyeListele : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_uyeler.DataSource = vrktmn.uyeListele();
            lv_uyeler.DataBind();
        }

        protected void lv_uyeler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idUye = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                vrktmn.uyeSil(idUye);
            }
            lv_uyeler.DataSource = vrktmn.uyeListele();
            lv_uyeler.DataBind();
        }
    }
}