using HaliSaha.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaha.Model
{
    public class OyuncuModel
    {
        public int OyuncuID { get; set; }
        public Nullable<int> KullaniciID { get; set; }
        public string OyuncuAdi { get; set; }
        public string OyuncuSoyadi { get; set; }
        public int MevkiID { get; set; }
        public string OyuncuTelefon { get; set; }
        public bool Durum { get; set; }
        public Nullable<bool> OyuncuSilmedurum { get; set; }

        public Nullable<int> SahaID { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public Nullable<int> MacSaati { get; set; }

        public KullaniciGirisTablo KullaniciGirisTablo = new KullaniciGirisTablo();

        public MevkiTablo MevkiTablo = new MevkiTablo();

        public SahaTablo SahaTablo = new SahaTablo();
    }
}