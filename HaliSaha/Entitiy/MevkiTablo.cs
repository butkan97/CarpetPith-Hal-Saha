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
    
    public partial class MevkiTablo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MevkiTablo()
        {
            this.OyuncuTablo = new HashSet<OyuncuTablo>();
        }
    
        public int MevkiID { get; set; }
        public string Mevki { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OyuncuTablo> OyuncuTablo { get; set; }
    }
}
