using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class eserListele : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_eserler_aktif.DataSource = vrktmn.eserListele(true);
            lv_eserler_aktif.DataBind();
            lv_eserler_pasif.DataSource = vrktmn.eserListele(false);
            lv_eserler_pasif.DataBind();
        }

        protected void lv_eserler_aktif_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idAktif = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                vrktmn.eserSil(idAktif);
            }
            if (e.CommandName == "durum")
            {
                vrktmn.eserDuzenle(idAktif);
            }
            lv_eserler_aktif.DataSource = vrktmn.eserListele(true);
            lv_eserler_aktif.DataBind();
            lv_eserler_pasif.DataSource = vrktmn.eserListele(false);
            lv_eserler_pasif.DataBind();
        }

        protected void lv_eserler_pasif_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idPasif = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                vrktmn.eserSil(idPasif);
            }
            if (e.CommandName == "durum")
            {
                vrktmn.eserDuzenle(idPasif);
            }
            lv_eserler_aktif.DataSource = vrktmn.eserListele(true);
            lv_eserler_aktif.DataBind();
            lv_eserler_pasif.DataSource = vrktmn.eserListele(false);
            lv_eserler_pasif.DataBind();
        }
    }
}