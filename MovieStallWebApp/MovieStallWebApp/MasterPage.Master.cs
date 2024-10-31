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
            secilenTur ST = vrktmn.sonSecilenGetir();
            int secilen = ST.SonSecilen;
            rpt_kategoriler.DataSource = vrktmn.tureAitKategorileriListele(secilen);
            rpt_kategoriler.DataBind();
        }

        protected void lbtn_film_Click(object sender, EventArgs e)
        {
            rpt_kategoriler.DataSource = vrktmn.tureAitKategorileriListele(1);
            rpt_kategoriler.DataBind();
            vrktmn.sonSecilenGuncelle(1);
        }

        protected void lbtn_kisafilm_Click(object sender, EventArgs e)
        {
            rpt_kategoriler.DataSource = vrktmn.tureAitKategorileriListele(2);
            rpt_kategoriler.DataBind();
            vrktmn.sonSecilenGuncelle(2);
        }

        protected void lbtn_dizi_Click(object sender, EventArgs e)
        {
            rpt_kategoriler.DataSource = vrktmn.tureAitKategorileriListele(3);
            rpt_kategoriler.DataBind();
            vrktmn.sonSecilenGuncelle(3);
        }

        protected void lbtn_belgesel_Click(object sender, EventArgs e)
        {
            rpt_kategoriler.DataSource = vrktmn.tureAitKategorileriListele(4);
            rpt_kategoriler.DataBind();
            vrktmn.sonSecilenGuncelle(4);
        }
    
    }
}