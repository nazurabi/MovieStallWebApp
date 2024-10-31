using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class oyuncununFilmleri : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                Response.Redirect("oyuncuListele.aspx");
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["OyuncuID"]);
                lv_oyuncununFilmleri.DataSource = vrktmn.oyuncuyaAitFilmleriListele(id);
                lv_oyuncununFilmleri.DataBind();
                oyuncu O = vrktmn.oyuncuGetir(id);
                lbl_oyuncuAdi.Text = O.OyuncuIsmi + " " + O.OyuncuSoyisim;
                lv_genelListe.DataSource = vrktmn.eserListele();
                lv_genelListe.DataBind();
            }
        }

        protected void lv_oyuncununFilmleri_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idSil = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {

                vrktmn.oyuncudanFilmSil(idSil);
            }
            int id = Convert.ToInt32(Request.QueryString["OyuncuID"]);
            lv_oyuncununFilmleri.DataSource = vrktmn.oyuncuyaAitFilmleriListele(id);
            lv_oyuncununFilmleri.DataBind();
            oyuncu O = vrktmn.oyuncuGetir(id);
            lbl_oyuncuAdi.Text = O.OyuncuIsmi + " " + O.OyuncuSoyisim;
            lv_genelListe.DataSource = vrktmn.eserListele();
            lv_genelListe.DataBind();
        }

        protected void lv_genelListe_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idFilmEkle = Convert.ToInt32(e.CommandArgument);
            oyuncununfilmleri OF = new oyuncununfilmleri();
            OF.OyuncuIDFK = Convert.ToInt32(Request.QueryString["OyuncuID"]);
            OF.EserBilgisiIDFK = idFilmEkle;
            if (e.CommandName == "liste")
            {
                vrktmn.oyuncuyaFilmEkle(OF);
            }
            int id = Convert.ToInt32(Request.QueryString["OyuncuID"]);
            lv_oyuncununFilmleri.DataSource = vrktmn.oyuncuyaAitFilmleriListele(id);
            lv_oyuncununFilmleri.DataBind();
            oyuncu O = vrktmn.oyuncuGetir(id);
            lbl_oyuncuAdi.Text = O.OyuncuIsmi + " " + O.OyuncuSoyisim;
            lv_genelListe.DataSource = vrktmn.eserListele();
            lv_genelListe.DataBind();
        }
    }
}