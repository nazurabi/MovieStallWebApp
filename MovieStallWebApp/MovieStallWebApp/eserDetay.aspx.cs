using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace MovieStallWebApp
{
    public partial class eserDetay : System.Web.UI.Page
    {
        verikatmani vrktmn = new verikatmani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["EserBilgisiID"]);
                    vrktmn.eserGoruntulemeArttir(id);
                    eser E = vrktmn.eserGetir(id);
                    img_resim.ImageUrl = "../resimler/EserResimleri/" + E.KapakResmi;
                    ltrl_tur.Text = E.TurIsmi;
                    ltrl_isim.Text = E.Isim;
                    ltrl_yil.Text = E.Yil;
                    ltrl_imdb.Text = E.ImdbPuani;
                    ltrl_vizyonTarihi.Text = E.VizyonTarihi;
                    ltrl_konu.Text = E.Konusu;
                    ltrl_eserAdi.Text = E.Isim;

                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }
}