﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNTTFAQ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CAU_HOI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAU_HOI()
        {
            this.CAU_TRA_LOI = new HashSet<CAU_TRA_LOI>();
        }
    
        public int ID { get; set; }

        [Required(ErrorMessage = "Trường thông tin câu hỏi là bắt buộc")]
        public string CAU_HOI1 { get; set; }
        
        public string MO_TA { get; set; }

        public Nullable<System.DateTime> NGAY_TAO { get; set; }
        public int ID_DANH_MUC { get; set; }
        public string ID_TAI_KHOAN { get; set; }
        public int LUOT_XEM { get; set; }
        public Nullable<bool> DUYET_DANG { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual DANH_MUC DANH_MUC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAU_TRA_LOI> CAU_TRA_LOI { get; set; }
    }
}
