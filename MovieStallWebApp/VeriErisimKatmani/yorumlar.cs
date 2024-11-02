using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class yorumlar
    {
        public int YrmID { get; set; }
        public int UyeIDFK { get; set; }
        public int EserBilgisiIDFK { get; set; }
        public string Yorum { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public string MovieStallPuani { get; set; }
        public bool Durum { get; set; }

    }
}
