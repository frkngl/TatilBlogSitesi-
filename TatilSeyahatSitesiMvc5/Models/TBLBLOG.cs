//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TatilSeyahatSitesiMvc5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLBLOG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLBLOG()
        {
            this.TBLYORUMLAR = new HashSet<TBLYORUMLAR>();
        }
    
        public int ID { get; set; }
        public string Baslik { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string Aciklama { get; set; }
        public string BlogImage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLYORUMLAR> TBLYORUMLAR { get; set; }
    }
}