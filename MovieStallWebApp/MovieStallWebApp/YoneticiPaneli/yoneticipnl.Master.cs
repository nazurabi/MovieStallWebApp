using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp.YoneticiPaneli
{
    public partial class yoneticipnl : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Yonetici"] != null)
            {
                yonetici Y = (yonetici)Session["Yonetici"];
                lbl_kullanicibilgi.Text = Y.KullaniciAdi + " (" + Y.YntTur + ")";
            }
            else
            {
                Response.Redirect("giris.aspx");
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["Yonetici"] =null;
            Response.Redirect("giris.aspx");
        }
    }
}