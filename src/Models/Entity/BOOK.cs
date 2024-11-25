//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagementSystem.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class BOOK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOOK()
        {
            this.LOANS = new HashSet<LOANS>();
        }
    
        public int ID { get; set; }
        public string NAME { get; set; }
        public string PUBLISHDATE { get; set; }
        public string PUBLISHER { get; set; }
        public string PAGE { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public Nullable<byte> CATEGORY_ID { get; set; }
        public Nullable<int> AUTHOR_ID { get; set; }
        public string BOOKIMAGE { get; set; }
    
        public virtual AUTHOR AUTHOR { get; set; }
        public virtual CATEGORY CATEGORY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOANS> LOANS { get; set; }
    }
}
