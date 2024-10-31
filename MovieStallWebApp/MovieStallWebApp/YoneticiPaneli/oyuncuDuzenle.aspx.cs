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
    public partial class oyuncuDuzenle : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["oyuncuID"]);
                    oyuncu O = vrktmn.oyuncuGetir(id);
                    if (O != null)
                    {
                        tb_oyuncuAdi.Text = O.OyuncuIsmi;
                        tb_oyuncuSoyismi.Text = O.OyuncuSoyisim;
                        tb_cinsiyet.Text = O.Cinsiyet;
                        tb_dogumTarihi.Text = O.DogumTarihi;
                        tb_dogumYeri.Text = O.DogumYeri;
                        tb_biyografi.Text = O.Biyografi;
                        img_resim.ImageUrl = "../resimler/OyuncuResimleri/" + O.KapakResmi;
                    }
                    else
                    {
                        Response.Redirect("oyuncuListele.aspx");
                    }
                }
            }
        }

        protected void lbtn_oyuncuDuzenle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_oyuncuAdi.Text))
            {

                int id = Convert.ToInt32(Request.QueryString["oyuncuID"]);
                oyuncu O = vrktmn.oyuncuGetir(id);
                O.OyuncuID = id;
                O.OyuncuIsmi = tb_oyuncuAdi.Text;
                O.OyuncuSoyisim = tb_oyuncuSoyismi.Text;
                O.Cinsiyet = tb_cinsiyet.Text;
                O.DogumTarihi = tb_dogumTarihi.Text;
                O.DogumYeri = tb_dogumYeri.Text;
                O.Biyografi = tb_biyografi.Text;
                O.DuzenlenmeTarihi = DateTime.Now;

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
                if (vrktmn.oyuncuGuncelle(O))
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Oyuncu Bilgileri Başarılı Şekilde Düzenlendi";
                    lbl_bilgi.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Oyuncu Bilgileri Düzenlenirken Bir Hata Oluştu";
                    lbl_bilgi.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lbl_bilgi.Visible = true;
                lbl_bilgi.Text = "Oyuncu Adı Boş Bırakılamaz";
                lbl_bilgi.BackColor = System.Drawing.Color.Red;
            }
        }
    }
}