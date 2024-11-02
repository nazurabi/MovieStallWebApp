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
    public partial class uyeOl : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_uyeOl_Click(object sender, EventArgs e)
        {
            if (tb_isim.Text!="" && tb_soyisim.Text!="" && tb_kullaniciAdi.Text != "" && tb_mail.Text != "" && tb_sifre.Text != "")
            {
                uyeler U = new uyeler();
                U.Isim = tb_isim.Text;
                U.Soyisim = tb_soyisim.Text;
                U.KullaniciAdi = tb_kullaniciAdi.Text;
                U.Mail= tb_mail.Text;
                U.Sifre= tb_sifre.Text;
                U.Durum = true;
                if (fu_resim.HasFile)
                {
                    string isim = Guid.NewGuid().ToString();
                    string dosyaYolu = fu_resim.FileName;
                    FileInfo fi = new FileInfo(dosyaYolu);
                    string uzanti = fi.Extension;
                    string dosyaIsmi = isim + uzanti;
                    fu_resim.SaveAs(Server.MapPath("resimler/Avatarlar/" + dosyaIsmi));
                    U.Avatar= dosyaIsmi;
                }
                else
                {
                    U.Avatar = "../../resimler/none.gif";
                }
                if (vrktmn.uyeEkle(U))
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Üyelik Başarılı Şekilde Oluşturuldu";
                    lbl_bilgi.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Üye Olurken Bir Hata Oluştu";
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