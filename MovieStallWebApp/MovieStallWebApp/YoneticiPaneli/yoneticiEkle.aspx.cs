using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class yoneticiEkle : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Yonetici"] != null)
                {
                    yonetici Y = (yonetici)Session["Yonetici"];
                    if (Y.YntTurID == 1)
                    {
                        ddl_yoneticiTuru.DataSource = vrktmn.yoneticiListele();
                        ddl_yoneticiTuru.DataBind();
                    }
                    else
                    {
                        lbtn_yoneticiEkle.Visible = false;
                        lbl_bilgi.Visible = true;
                        lbl_bilgi.Text = "Admin Yetkisinde Değilsiniz";
                        lbl_bilgi.BackColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void lbtn_yoneticiEkle_Click(object sender, EventArgs e)
        {
            if (tb_isim.Text != "" && tb_soyisim.Text != "" && tb_kullaniciAdi.Text != "" && tb_mail.Text != "" && tb_sifre.Text != "")
            {
                yonetici Y = new yonetici();
                Y.YntTurID = Convert.ToInt32(ddl_yoneticiTuru.SelectedItem.Value);
                Y.Isim = tb_isim.Text;
                Y.Soyisim = tb_soyisim.Text;
                Y.KullaniciAdi = tb_kullaniciAdi.Text;
                Y.Mail = tb_mail.Text;
                Y.Sifre = tb_sifre.Text;
                Y.Durum = cb_durum.Checked;

                if (vrktmn.yoneticiEkle(Y))
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Yönetici Başarılı Şekilde Eklendi";
                    lbl_bilgi.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Yönetici Eklenirken Bir Hata Oluştu";
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