using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class kategoriDuzenle : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                Response.Redirect("kategoriListele.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["KategoriID"]);
                    kategori K = vrktmn.kategoriGetir(id);
                    if (K != null)
                    {
                        tb_kategoriadi.Text = K.KategoriIsmi;
                        cb_durum.Checked = K.Durum;

                    }
                    else
                    {
                        Response.Redirect("kategoriListele.aspx");
                    }
                }
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kategoriadi.Text))
            {
                int id = Convert.ToInt32(Request.QueryString["KategoriID"]);
                kategori K = vrktmn.kategoriGetir(id);
                K.KategoriIsmi = tb_kategoriadi.Text;
                K.Durum = cb_durum.Checked;
                if (vrktmn.kategoriGuncelle(K))
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Kategori Başarılı Şekilde Güncellendi";
                    lbl_bilgi.BackColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    lbl_bilgi.Visible = true;
                    lbl_bilgi.Text = "Kategori Düzenleme Başarısız";
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
