using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class yonetmeninFilmleri : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                Response.Redirect("yonetmenListele.aspx");
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["YonetmenID"]);
                lv_yonetmeninFilmleri.DataSource = vrktmn.yonetmeneAitFilmleriListele(id);
                lv_yonetmeninFilmleri.DataBind();
                yonetmen Y = vrktmn.yonetmenGetir(id);
                lbl_yonetmenAdi.Text = Y.YonetmenIsmi + " " + Y.YonetmenSoyisim;
                lv_genelListe.DataSource = vrktmn.eserListele();
                lv_genelListe.DataBind();
            }
        }


        protected void lv_yonetmeninFilmleri_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idSil = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {

                vrktmn.yonetmendenFilmSil(idSil);
            }
            int id = Convert.ToInt32(Request.QueryString["YonetmenID"]);
            lv_yonetmeninFilmleri.DataSource = vrktmn.yonetmeneAitFilmleriListele(id);
            lv_yonetmeninFilmleri.DataBind();
            yonetmen Y = vrktmn.yonetmenGetir(id);
            lbl_yonetmenAdi.Text = Y.YonetmenIsmi + " " + Y.YonetmenSoyisim;
            lv_genelListe.DataSource = vrktmn.eserListele();
            lv_genelListe.DataBind();
        }

        protected void lv_genelListe_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idFilmEkle = Convert.ToInt32(e.CommandArgument);
            yonetmeninfilmleri YF = new yonetmeninfilmleri();
            YF.YonetmenIDFK = Convert.ToInt32(Request.QueryString["YonetmenID"]);
            YF.EserBilgisiIDFK = idFilmEkle;
            if (e.CommandName == "liste")
            {
                vrktmn.yonetmeneFilmEkle(YF);
            }
            int id = Convert.ToInt32(Request.QueryString["YonetmenID"]);
            lv_yonetmeninFilmleri.DataSource = vrktmn.yonetmeneAitFilmleriListele(id);
            lv_yonetmeninFilmleri.DataBind();
            yonetmen Y = vrktmn.yonetmenGetir(id);
            lbl_yonetmenAdi.Text = Y.YonetmenIsmi + " " + Y.YonetmenSoyisim;
            lv_genelListe.DataSource = vrktmn.eserListele();
            lv_genelListe.DataBind();
        }
    }
}