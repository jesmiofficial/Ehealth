//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ehealth.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class test_results
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public test_results()
        {
            this.patients = new HashSet<patient>();
        }
    
        public int id { get; set; }
        public int patient_id { get; set; }
        public string patientNhsNo { get; set; }
        public int test_type_id { get; set; }
        public string result { get; set; }
        public int user_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<patient> patients { get; set; }
        public virtual patient patient { get; set; }
        public virtual test_types test_types { get; set; }
        public virtual user user { get; set; }
    }
}