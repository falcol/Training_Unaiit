using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Training_Unaiit.Models.Faculty;
using Training_Unaiit.Models.Grade;
using Training_Unaiit.Models.School;

namespace Unaiit.Models
{
    public class AppUser : IdentityUser
    {
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Quê quán")]
        [StringLength(250, ErrorMessage = "Quê quán không được vượt quá 250 ký tự")]
        public string HomeAddress { get; set; } = default!;

        [DataType(DataType.Date)]
        public DateTime DeletedAt { get; set; } = default!;

        [Display(Name = "Loại tài khoản")]
        public int type { get; set; } = 0;

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } = default!;

        [Display(Name = "Tên")]
        [StringLength(100, ErrorMessage = "Tên không được vượt quá 250 ký tự")]
        public string Name { get; set; } = default!;
    }
}
