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

    public partial class GUI_CAU_HOI
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập tiêu đề câu hỏi")]
        public string CAU_HOI_MUON_HOI { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập mô tả vào ô này")]
        public string MO_TA { get; set; }

        public Nullable<System.DateTime> NGAY_CHINH_SUA { get; set; }
        public string ID_TAI_KHOAN { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập Họ và Tên vào ô này")]
        public string HO_TEN { get; set; }
        public bool TRANG_THAI { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}