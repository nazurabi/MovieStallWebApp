using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;
namespace MovieStallWebApp
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UyeBilgi"] != null)
            {
                uyeler U = (uyeler)Session["UyeBilgi"];
                lbl_kullanicibilgi.Text = U.KullaniciAdi;
            }
            //if (IsPostBack)

            //{
            //    Response.Redirect("Default.aspx");
            //}


        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["UyeBilgi"] = null;
            Response.Redirect("uyeGirisi.aspx");
        }
    }
}