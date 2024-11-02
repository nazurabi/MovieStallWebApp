using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class yoneticiDuzenle : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                Response.Redirect("yoneiciListele.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["YntID"]);
                    yonetici Y = vrktmn.yoneticiGetir(id);
                    if (Y != null)
                    {
                        ddl_yoneticiTuru.DataSource = vrktmn.yoneticiTuruListele();
                        ddl_yoneticiTuru.DataBind();
                        ddl_yoneticiTuru.SelectedValue = Convert.ToString(Y.YntTurID);
                        tb_isim.Text = Y.Isim;
                        tb_soyisim.Text = Y.Soyisim;
                        tb_kullaniciAdi.Text = Y.KullaniciAdi;
                        tb_mail.Text = Y.Mail;
                        tb_sifre.Text = Y.Sifre;
                        cb_durum.Checked = Y.Durum;
                    }
                    else
                    {
                        Response.Redirect("yonetmenListele.aspx");
                    }
                }
            }
        }

        protected void lbtn_yoneticiDuzenle_Click(object sender, EventArgs e)
        {
            if (tb_isim.Text != "" && tb_soyisim.Text != "" && tb_kullaniciAdi.Text != "" && tb_mail.Text != "")
            {
                int id = Convert.ToInt32(Request.QueryString["YntID"]);
                yonetici Y = vrktmn.yoneticiGetir(id);
                Y.YntID = id;
                Y.YntTurID = Convert.ToInt32(ddl_yoneticiTuru.SelectedItem.Value);
                Y.Isim = tb_isim.Text;
                Y.Soyisim = tb_soyisim.Text;
                Y.KullaniciAdi = tb_kullaniciAdi.Text;
                Y.Mail = tb_mail.Text;
                if (tb_sifre.Text != "")
                {
                    Y.Sifre = tb_sifre.Text;
                }
                Y.Durum = cb_durum.Checked;

                if (vrktmn.yoneticiGuncelle(Y))
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Yönetici Başarılı Şekilde Düzenlendi";
                    lbl_bilgi.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Yönetici Düzenlenirken Bir Hata Oluştu";
                    lbl_bilgi.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lbl_bilgi.Visible = true;
                lbl_bilgi.Text = "Boş Alanlar Mevcut";
                lbl_bilgi.BackColor = System.Drawing.Color.Red;
            }
        }
    }
}