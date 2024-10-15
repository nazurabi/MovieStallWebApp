using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class eser
    {
        public int EserBilgisiID { get; set; }
        public int TurIDFK { get; set; }
        public string TurIsmi { get; set; }
        public int KategoriIDFK { get; set; }
        public string KategoriIsmi { get; set; }
        public string Isim { get; set; }
        public string Yil { get; set; }
        public string ImdbPuani { get; set; }
        public string VizyonTarihi { get; set; }
        public string Konusu { get; set; }
        public string Oyuncular { get; set; }
        public string Yonetmen { get; set; }
        public long GoruntulemeSayisi { get; set; }
        public string KapakResmi { get; set; }
        public string Yorum { get; set; }
        public string MovieStallPuani { get; set; }
        public string EklemeTarihi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Avatar { get; set; }
    }
}
