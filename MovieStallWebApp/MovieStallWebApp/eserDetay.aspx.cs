using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp
{
    public partial class eserDetay : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UyeBilgi"] != null)
            {
                lbl_girisKontrol.Visible = false;
                tb_yorum.Visible = true;
                lbtn_yorumEkle.Visible = true;
            }

            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["EserBilgisiID"]);
                    vrktmn.eserGoruntulemeArttir(id);
                    eser E = vrktmn.eserDetayGetir(id);
                    img_resim.ImageUrl = "../resimler/EserResimleri/" + E.KapakResmi;
                    ltrl_tur.Text = E.TurIsmi;
                    ltrl_isim.Text = E.Isim;
                    ltrl_yil.Text = E.Yil;
                    ltrl_imdb.Text = E.ImdbPuani;
                    ltrl_vizyonTarihi.Text = E.VizyonTarihi;
                    ltrl_konu.Text = E.Konusu;
                    ltrl_eserAdi.Text = E.Isim;
                    for (int i = 0; i < E.Yonetmen.Length; i++) // Yönetmen görüntülemeleri hatalı düzelt !!!
                    {
                        ltrl_yonetmen.Text = ltrl_yonetmen.Text + " " + E.Yonetmen[i];
                    }
                    for (int i = 0; i < E.Oyuncu.Length; i++)
                    {
                        ltrl_oyuncu.Text = ltrl_oyuncu.Text + " " + E.Oyuncu[i];
                    }

                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void lbtn_yorumEkle_Click(object sender, EventArgs e)
        {
            if (Session["UyeBilgi"] != null)
            {
                uyeler U = (uyeler)Session["UyeBilgi"];
                if (!string.IsNullOrEmpty(tb_yorum.Text))
                {
                    int id = Convert.ToInt32(Request.QueryString["EserBilgisiID"]);
                    eser E = vrktmn.eserDetayGetir(id);

                    yorumlar Y = new yorumlar();

                    Y.UyeIDFK = U.UyeID;
                    Y.EserBilgisiIDFK = E.EserBilgisiID;
                    Y.Yorum = tb_yorum.Text;
                    Y.EklemeTarihi = DateTime.Now;
                    Y.MovieStallPuani = ddl_moviestallPuani.SelectedIndex.ToString();
                    Y.Durum = false;

                    if (vrktmn.yorumEkle(Y))
                    {
                        lbl_bilgi.Visible = true;
                        lbl_bilgi.Text = "Yorum Başarılı Şekilde Eklendi";
                        lbl_bilgi.BackColor = System.Drawing.Color.ForestGreen;
                    }
                    else
                    {
                        lbl_bilgi.Visible = true;
                        lbl_bilgi.Text = "Yorum Eklenirken Bir Hata Oluştu";
                        lbl_bilgi.BackColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Yorum Boş Bırakılamaz";
                    lbl_bilgi.BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}