using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani; 
namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class giris : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tb_mail.Text))
            {
                if(!string.IsNullOrEmpty(tb_sifre.Text))
                {
                    yonetici Y = vrktmn.yoneticiGirisi(tb_mail.Text, tb_sifre.Text);
                    if(Y!=null)
                    {
                        Session["Yonetici"] = Y;
                        Response.Redirect("yoneticiDefault.aspx");
                    }
                    else
                    {
                        girisbilgipaneli.Visible = true;
                        lbl_mesaj.Text = "Kullanıcı Bulunamadı";
                    }
                }
                else
                {
                    girisbilgipaneli.Visible = true;
                    lbl_mesaj.Text = "Şifre Boş Bırakılamaz";
                }
            }
            else
            {
                girisbilgipaneli.Visible = true;
                lbl_mesaj.Text = "Mail Adresi Boş Bırakılamaz";
            }
        }
    }
}