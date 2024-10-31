using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class yonetmen
    {
        public int YonetmenID { get; set; }
        public string YonetmenIsmi { get; set; }
        public string YonetmenSoyisim { get; set; }
        public string Cinsiyet { get; set; }
        public string Biyografi { get; set; }
        public string DogumTarihi { get; set; }
        public string DogumYeri { get; set; }
        public string KapakResmi { get; set; }
        public DateTime DuzenlenmeTarihi { get; set; }

    }
}
