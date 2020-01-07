using HaliSaha.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaha.Model
{
    public class TakimModel
    {
        public int TakımID { get; set; }
        public int KullaniciID { get; set; }
        public string TakımAdı { get; set; }
        public string Telefon { get; set; }
        public int SemtID { get; set; }
        public bool TakımDurum { get; set; }
       // public System.DateTime Tarih { get; set; }

        public Nullable<System.DateTime> Tarih { get; set; }
        public bool TakımSilmedurum { get; set; }

        public Nullable<int> MacSaati { get; set; }
        public int SahaID { get; set; }

        public SahaTablo SahaTablo = new SahaTablo();

        public KullaniciGirisTablo KullaniciGirisTablo = new KullaniciGirisTablo();

        public SemtTablo SemtTablo = new SemtTablo();
    }
}
