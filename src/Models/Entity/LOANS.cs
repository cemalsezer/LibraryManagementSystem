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
    
    public partial class LOANS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOANS()
        {
            this.PUNISHMENT = new HashSet<PUNISHMENT>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> BORROWDATE { get; set; }
        public Nullable<System.DateTime> DUEDATE { get; set; }
        public Nullable<int> BOOK_ID { get; set; }
        public Nullable<int> USER_ID { get; set; }
        public byte STAFF_ID { get; set; }
        public Nullable<bool> OPERATIONSSTATE { get; set; }
        public Nullable<System.DateTime> USERRETURN { get; set; }
    
        public virtual BOOK BOOK { get; set; }
        public virtual USER USER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PUNISHMENT> PUNISHMENT { get; set; }
        public virtual STAFF STAFF { get; set; }
    }
}
