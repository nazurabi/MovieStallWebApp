using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class eserEkle : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_tur.DataSource = vrktmn.turListele();
                ddl_tur.DataBind();
            }
        }

        protected void lbtn_eserEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_eserAdi.Text))
            {
                eser E = new eser();
                E.TurIDFK = Convert.ToInt32(ddl_tur.SelectedItem.Value);
                E.Isim = tb_eserAdi.Text;
                E.Yil = tb_yil.Text;
                E.ImdbPuani = tb_imdb.Text;
                E.VizyonTarihi = tb_vizyonTarihi.Text;
                E.Konusu = tb_konu.Text;
                E.GoruntulemeSayisi = 0;
                E.YayinDurum = cb_yayinla.Checked;       
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
                else
                {
                    E.KapakResmi = "../../resimler/none.gif";
                }
                if(vrktmn.eserEkle(E))
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Eser Başarılı Şekilde Eklendi";
                    lbl_bilgi.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Eser Eklenirken Bir Hata Oluştu";
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