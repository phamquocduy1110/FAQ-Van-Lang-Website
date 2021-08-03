using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNTTFAQ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MailModel
    {
        [Required(ErrorMessage = "Mời bạn nhập Email của Ban Chủ Nhiệm Khoa")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email address")]
        public string From { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập Email người cần gửi")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email address")]
        public string To { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập tiêu đề Email")]
        [MinLength(5, ErrorMessage = "Tiêu đề email phải tối thiếu ít nhất là 5 kí tự")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mời bạn nhập nội dung")]
        public string Body { get; set; }
    }
}