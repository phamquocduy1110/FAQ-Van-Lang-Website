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

    public partial class DANH_MUC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DANH_MUC()
        {
            this.CAU_HOI = new HashSet<CAU_HOI>();
        }
    
        public int ID { get; set; }

        [Required(ErrorMessage = "Trường thông tin danh mục là bắt buộc")]
        public string DANH_MUC1 { get; set; }

        public string MO_TA { get; set; }

        [Required(ErrorMessage = "Trường thông tin hình ảnh là bắt buộc")]
        public string HINH_ANH { get; set; }
        public Nullable<System.DateTime> NGAY_TAO { get; set; }
        public string ID_TAI_KHOAN { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAU_HOI> CAU_HOI { get; set; }
    }
}
