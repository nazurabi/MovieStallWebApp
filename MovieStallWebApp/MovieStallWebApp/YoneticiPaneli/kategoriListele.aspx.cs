using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class kategoriListele : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_kategorilerAktif.DataSource = vrktmn.kategoriListele(false);
            lv_kategorilerAktif.DataBind();
            lv_kategorilerSilinmis.DataSource = vrktmn.kategoriListele(true);
            lv_kategorilerSilinmis.DataBind();
        }

        protected void lv_kategorilerAktif_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idAktif = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                vrktmn.kategoriSil(idAktif);
            }
            if (e.CommandName == "durum")
            {
                vrktmn.kategoriDuzenle(idAktif);
            }
            lv_kategorilerAktif.DataSource = vrktmn.kategoriListele(false);
            lv_kategorilerAktif.DataBind();
            lv_kategorilerSilinmis.DataSource = vrktmn.kategoriListele(true);
            lv_kategorilerSilinmis.DataBind();

        }

        protected void lv_kategorilerSilinmis_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idGeriAl = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "SilinmisiGeriAl")
            {
                vrktmn.kategoriSilinmisGeriAl(idGeriAl);
            }
            lv_kategorilerAktif.DataSource = vrktmn.kategoriListele(false);
            lv_kategorilerAktif.DataBind();
            lv_kategorilerSilinmis.DataSource = vrktmn.kategoriListele(true);
            lv_kategorilerSilinmis.DataBind();
        }
    }
}