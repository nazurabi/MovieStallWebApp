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
    public partial class eserDuzenle : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                Response.Redirect("eserListele.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["EserBilgisiID"]);
                    eser E = vrktmn.eserGetir(id);
                    if (E != null)
                    {
                        ddl_tur.DataSource = vrktmn.turListele();
                        ddl_tur.DataBind();
                        tb_eserAdi.Text = E.Isim;
                        tb_yil.Text = E.Yil;
                        tb_imdb.Text = E.ImdbPuani;
                        tb_vizyonTarihi.Text = E.VizyonTarihi;
                        tb_konu.Text = E.Konusu;
                        cb_yayinla.Checked = E.YayinDurum;
                        img_resim.ImageUrl = "../resimler/EserResimleri/" + E.KapakResmi;
                    }
                    else
                    {
                        Response.Redirect("eserListele.aspx");
                    }
                }
            }
        }

        protected void lbtn_eserDuzenle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_eserAdi.Text))
            {
                int id = Convert.ToInt32(Request.QueryString["EserBilgisiID"]);
                eser E = vrktmn.eserGetir(id);
                E.EserBilgisiID = id;
                E.TurIDFK = Convert.ToInt32(ddl_tur.SelectedItem.Value);
                E.Isim = tb_eserAdi.Text;
                E.Yil = tb_yil.Text;
                E.ImdbPuani = tb_imdb.Text;
                E.VizyonTarihi = tb_vizyonTarihi.Text;
                E.Konusu = tb_konu.Text;
                E.YayinDurum = cb_yayinla.Checked;
                E.DuzenlenmeTarihi = DateTime.Now;

                if (fu_resim.HasFile)
                {
                    string isim = Guid.NewGuid().ToString();
                    string dosyaYolu = fu_resim.FileName;
                    FileInfo fi = new FileInfo(dosyaYolu);
                    string uzanti = fi.Extension;
                    string dosyaIsmi = isim + uzanti;
                    fu_resim.SaveAs(Server.MapPath("../resimler/EserResimleri/" + dosyaIsmi));
                    E.KapakResmi = dosyaIsmi;
                }
                if (vrktmn.eserGuncelle(E))
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Eser Başarılı Şekilde Düzenlendi";
                    lbl_bilgi.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Eser Düzenlenirken Bir Hata Oluştu";
                    lbl_bilgi.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lbl_bilgi.Visible = true;
                lbl_bilgi.Text = "Eser Adı Boş Bırakılamaz";
                lbl_bilgi.BackColor = System.Drawing.Color.Red;
            }
        }
    }
}