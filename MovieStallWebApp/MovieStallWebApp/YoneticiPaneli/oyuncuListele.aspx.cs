using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class oyuncuListele : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_oyuncular.DataSource = vrktmn.oyuncuListele();
            lv_oyuncular.DataBind();
        }

        protected void lv_oyuncular_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idOyuncu = Convert.ToInt32(e.CommandArgument);
            if(e.CommandName=="sil")
            {
                vrktmn.oyuncuSil(idOyuncu);
            }
            lv_oyuncular.DataSource = vrktmn.oyuncuListele();
            lv_oyuncular.DataBind();
        }
    }
}