using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class kategoriEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lbl_bilgi.Text = "Kategori Eklenemedi";
            //lbl_bilgi.BackColor = System.Drawing.Color.Red;
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            verikatmani vrktmn = new verikatmani();
            if (!string.IsNullOrEmpty(tb_kategoriadi.Text))
            {
                kategori K = new kategori();
                K.KategoriIsmi = tb_kategoriadi.Text;
                K.Durum = cb_durum.Checked;
                K.Silinmis = cb_silinmis.Checked;
               if(vrktmn.kategoriEkle(K))
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Kategori Başarılı Şekilde Eklendi";
                    lbl_bilgi.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Kategori Adı Boş Bırakılamaz";
                    lbl_bilgi.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lbl_bilgi.Visible = true;
                lbl_bilgi.Text = "Kategori Adı Boş Bırakılamaz";
                lbl_bilgi.BackColor = System.Drawing.Color.Red;
            }
        }
    }
}