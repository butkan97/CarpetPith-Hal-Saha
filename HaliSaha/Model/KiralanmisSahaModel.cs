using HaliSaha.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaha.Model
{
    public class KiralanmisSahaModel
    {
        public int KSID { get; set; }
        public Nullable<int> KullaniciID { get; set; }
        public Nullable<int> SahaID { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public Nullable<int> SaatBaslangic { get; set; }
        public Nullable<int> SaatBitis { get; set; }

        public Nullable<int> SemtID { get; set; }

        public KullaniciGirisTablo KullaniciGirisTablo = new KullaniciGirisTablo();

        public SahaTablo SahaTablo = new SahaTablo();
    }
}
