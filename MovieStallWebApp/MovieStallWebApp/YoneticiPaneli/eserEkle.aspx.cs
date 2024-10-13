using System;
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
            ddl_tur.DataSource = vrktmn.turListele();
            ddl_tur.DataBind();

            ddl_kategori.DataSource = vrktmn.kategoriListele(false,true);
            ddl_kategori.DataBind();
        }
    }
}