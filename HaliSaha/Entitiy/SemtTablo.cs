//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HaliSaha.Entitiy
{
    using System;
    using System.Collections.Generic;
    
    public partial class SemtTablo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SemtTablo()
        {
            this.KiralanmışSahaTablo = new HashSet<KiralanmışSahaTablo>();
            this.SahaTablo = new HashSet<SahaTablo>();
            this.TakımTablo = new HashSet<TakımTablo>();
        }
    
        public int SemtID { get; set; }
        public string SemtAdi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KiralanmışSahaTablo> KiralanmışSahaTablo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SahaTablo> SahaTablo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TakımTablo> TakımTablo { get; set; }
    }
}
