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
    public partial class oyuncuEkle : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_oyuncuEkle_Click(object sender, EventArgs e)
        {
            if (tb_isim.Text != "" && tb_soyisim.Text != "" && tb_cinsiyet.Text != "" && tb_biyografi.Text != "" && tb_dogumtarihi.Text != "" && tb_dogumtarihi.Text != "")
            {
                oyuncu O = new oyuncu();
                O.OyuncuIsmi = tb_isim.Text;
                O.OyuncuSoyisim = tb_soyisim.Text;
                O.Cinsiyet = tb_cinsiyet.Text;
                O.Biyografi = tb_biyografi.Text;
                O.DogumTarihi = tb_dogumtarihi.Text;
                O.DogumYeri = tb_dorumyeri.Text;
                if (fu_resim.HasFile)
                {
                    string isim = Guid.NewGuid().ToString();
                    string dosyaYolu = fu_resim.FileName;
                    FileInfo fi = new FileInfo(dosyaYolu);
                    string uzanti = fi.Extension;
                    string dosyaIsmi = isim + uzanti;
                    fu_resim.SaveAs(Server.MapPath("../resimler/OyuncuResimleri/" + dosyaIsmi));
                    O.KapakResmi = dosyaIsmi;
                }
                else
                {
                    O.KapakResmi = "../../resimler/none.gif";
                }
                if (vrktmn.oyuncuEkle(O))
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Oyuncu Başarılı Şekilde Eklendi";
                    lbl_bilgi.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Oyuncu Eklenirken Bir Hata Oluştu";
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