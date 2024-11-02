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
    public partial class uyeDuzenle : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                Response.Redirect("uyeListele.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["UyeID"]);
                    uyeler U = vrktmn.uyeGetir(id);
                    if (U != null)
                    {
                        tb_isim.Text = U.Isim;
                        tb_soyisim.Text = U.Soyisim;
                        tb_kullaniciAdi.Text = U.KullaniciAdi;
                        tb_mail.Text = U.Mail;
                        tb_sifre.Text = U.Sifre;
                        cb_durum.Checked = U.Durum;
                        img_resim.ImageUrl = "/resimler/Avatarlar/" + U.Avatar;
                    }
                    else
                    {
                        Response.Redirect("uyeListele.aspx");
                    }
                }
            }
        }

        protected void lbtn_uyeDuzenle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kullaniciAdi.Text))
            {
                int id = Convert.ToInt32(Request.QueryString["UyeID"]);
                uyeler U = vrktmn.uyeGetir(id);
                U.Isim = tb_isim.Text;
                U.Soyisim = tb_soyisim.Text;
                U.KullaniciAdi = tb_kullaniciAdi.Text;
                U.Mail = tb_mail.Text;
                if (tb_sifre.Text != "")
                {
                    U.Sifre = tb_sifre.Text;
                }
                U.Durum = cb_durum.Checked;
                if (fu_resim.HasFile)
                {
                    string isim = Guid.NewGuid().ToString();
                    string dosyaYolu = fu_resim.FileName;
                    FileInfo fi = new FileInfo(dosyaYolu);
                    string uzanti = fi.Extension;
                    string dosyaIsmi = isim + uzanti;
                    fu_resim.SaveAs(Server.MapPath("../resimler/Avatarlar/" + dosyaIsmi));
                    U.Avatar = dosyaIsmi;
                }

                if (vrktmn.uyeGuncelle(U))
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Üyelik Başarılı Şekilde Düzenlendi";
                    lbl_bilgi.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Üye Düzenlenirken Bir Hata Oluştu";
                    lbl_bilgi.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lbl_bilgi.Visible = true;
                lbl_bilgi.Text = "Kullanıcı Adı Boş Bırakılamaz";
                lbl_bilgi.BackColor = System.Drawing.Color.Red;
            }
        }
    }
}