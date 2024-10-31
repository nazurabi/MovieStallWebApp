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
        public long GoruntulemeSayisi { get; set; }
        public string KapakResmi { get; set; }
        public bool YayinDurum { get; set; }
        public string YayinDurumGostergesi { get; set; }
        public DateTime DuzenlenmeTarihi { get; set; }
        public int YFID { get; set; }
        public int KEserID { get; set; }
        public int OFID { get; set; }
        public int EserBilgisiIDFK { get; set; }


    }
}
