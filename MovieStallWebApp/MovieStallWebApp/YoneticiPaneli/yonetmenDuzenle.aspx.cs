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
    public partial class yonetmenDuzenle : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["YonetmenID"]);
                    yonetmen Y = vrktmn.yonetmenGetir(id);
                    if (Y != null)
                    {
                        tb_yonetmenAdi.Text = Y.YonetmenIsmi;
                        tb_yonetmenSoyismi.Text = Y.YonetmenSoyisim;
                        tb_cinsiyet.Text = Y.Cinsiyet;
                        tb_dogumTarihi.Text = Y.DogumTarihi;
                        tb_dogumYeri.Text = Y.DogumYeri;
                        tb_biyografi.Text = Y.Biyografi;
                        img_resim.ImageUrl = "../resimler/YonetmenResimleri/" + Y.KapakResmi;
                    }
                    else
                    {
                        Response.Redirect("yonetmenListele.aspx");
                    }
                }
            }
        }

        protected void lbtn_yonetmenDuzenle_Click(object sender, EventArgs e)
        {
            if (tb_yonetmenAdi.Text != "" && tb_yonetmenSoyismi.Text != "" && tb_cinsiyet.Text != "" && tb_biyografi.Text != "" && tb_dogumTarihi.Text != "" && tb_dogumYeri.Text != "")
            {
              
                int id= Convert.ToInt32(Request.QueryString["YonetmenID"]);
                yonetmen Y = vrktmn.yonetmenGetir(id);
                Y.YonetmenID = id;
                Y.YonetmenIsmi = tb_yonetmenAdi.Text;
                Y.YonetmenSoyisim = tb_yonetmenSoyismi.Text;
                Y.Cinsiyet = tb_cinsiyet.Text;
                Y.DogumTarihi = tb_dogumTarihi.Text;
                Y.DogumYeri = tb_dogumYeri.Text;
                Y.Biyografi = tb_biyografi.Text;
                Y.DuzenlenmeTarihi = DateTime.Now;

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
                if (vrktmn.yonetmenGuncelle(Y))
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Yönetmen Bilgileri Başarılı Şekilde Düzenlendi";
                    lbl_bilgi.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Yönetmen Bilgileri Düzenlenirken Bir Hata Oluştu";
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