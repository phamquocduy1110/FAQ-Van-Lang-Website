//------------------------------------------------------------------------------
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
    
    public partial class CAU_TRA_LOI
    {
        public int ID { get; set; }
        public int ID_CAU_HOI { get; set; }
        public string CAU_TRA_LOI1 { get; set; }
        public Nullable<System.DateTime> NGAY_TRA_LOI { get; set; }
        public string ID_TAI_KHOAN { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual CAU_HOI CAU_HOI { get; set; }
    }
}