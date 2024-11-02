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
    public partial class yonetmenEkle : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_yonetmenEkle_Click(object sender, EventArgs e)
        {
            if (tb_isim.Text != "" && tb_soyisim.Text != "" && tb_cinsiyet.Text != "" && tb_biyografi.Text != "" && tb_dogumtarihi.Text != "" && tb_dogumtarihi.Text != "")
            {
                yonetmen Y = new yonetmen();
                Y.YonetmenIsmi = tb_isim.Text;
                Y.YonetmenSoyisim = tb_soyisim.Text;
                Y.Cinsiyet = tb_cinsiyet.Text;
                Y.Biyografi = tb_biyografi.Text;
                Y.DogumTarihi = tb_dogumtarihi.Text;
                Y.DogumYeri = tb_dorumyeri.Text;
                if (fu_resim.HasFile)
                {
                    string isim = Guid.NewGuid().ToString();
                    string dosyaYolu = fu_resim.FileName;
                    FileInfo fi = new FileInfo(dosyaYolu);
                    string uzanti = fi.Extension;
                    string dosyaIsmi = isim + uzanti;
                    fu_resim.SaveAs(Server.MapPath("../resimler/YonetmenResimleri/" + dosyaIsmi));
                    Y.KapakResmi = dosyaIsmi;
                }
                else
                {
                    Y.KapakResmi = "../../resimler/none.gif";
                }
                if (vrktmn.yonetmenEkle(Y))
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Yönetmen Başarılı Şekilde Eklendi";
                    lbl_bilgi.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Yönetmen Eklenirken Bir Hata Oluştu";
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