using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class kategorininFilmleri : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                Response.Redirect("kategoriListele.aspx");
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["KategoriID"]);
                lv_kategorininFilmleri.DataSource = vrktmn.kategoriyeAitFilmleriListele(id);
                lv_kategorininFilmleri.DataBind();
                kategori K = vrktmn.kategoriGetir(id);
                lbl_kategoriAdi.Text = K.KategoriIsmi;
                lv_genelListe.DataSource = vrktmn.eserListele();
                lv_genelListe.DataBind();
            }
        }

        protected void lv_kategorininFilmleri_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idSil = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {

                vrktmn.kategoridenFilmSil(idSil);
            }
            int id = Convert.ToInt32(Request.QueryString["KategoriID"]);
            lv_kategorininFilmleri.DataSource = vrktmn.kategoriyeAitFilmleriListele(id);
            lv_kategorininFilmleri.DataBind();
            kategori K = vrktmn.kategoriGetir(id);
            lbl_kategoriAdi.Text = K.KategoriIsmi;
            lv_genelListe.DataSource = vrktmn.eserListele();
            lv_genelListe.DataBind();
        }

        protected void lv_genelListe_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int idFilmEkle = Convert.ToInt32(e.CommandArgument);
            kategoriyeaitfilmler KF = new kategoriyeaitfilmler();
            KF.KategoriIDFK = Convert.ToInt32(Request.QueryString["KategoriID"]);
            KF.EserBilgisiIDFK = idFilmEkle;
            if (e.CommandName == "liste")
            {
                vrktmn.kategoriyeFilmEkle(KF);
            }
            int id = Convert.ToInt32(Request.QueryString["KategoriID"]);
            lv_kategorininFilmleri.DataSource = vrktmn.kategoriyeAitFilmleriListele(id);
            lv_kategorininFilmleri.DataBind();
            kategori K = vrktmn.kategoriGetir(id);
            lbl_kategoriAdi.Text = K.KategoriIsmi;
            lv_genelListe.DataSource = vrktmn.eserListele();
            lv_genelListe.DataBind();
        }
    }
}