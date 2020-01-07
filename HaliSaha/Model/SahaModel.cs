using HaliSaha.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaliSaha.Model
{
    public class SahaModel
    {
        public int SahaID { get; set; }
        public string SahaAdi { get; set; }
        public int SemtID { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }

        public bool SahaSilmeDurum { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public OyuncuTablo OyuncuTablo = new OyuncuTablo();
        public SemtTablo SemtTablo = new SemtTablo();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public TakımTablo TakımTablo = new TakımTablo();
    }
}
