using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["KategoriID"]);
                    lv_kategorininFilmleri.DataSource = vrktmn.kategoriyeAitFilmleriListele(id,true);
                    lv_kategorininFilmleri.DataBind();
                    kategori K = vrktmn.kategoriGetir(id);
                    lbl_kategoriAdi.Text = K.KategoriIsmi;
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
     
    }
}