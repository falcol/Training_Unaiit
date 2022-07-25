using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Training_Unaiit.CustomValidate;
using Training_Unaiit.Models.Faculty;
using Unaiit.Models;

namespace Training_Unaiit.Models.Grade
{
    [Table("Grade")]
    public class GradeTable
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Cần phải có tên lớp")]
        [Display(Name = "Tên lớp")]
        [MaxLength(50, ErrorMessage = "Tên lớp không được vượt quá 50 ký tự")]
        public string? Name { get; set; }

        [Display(Name = "Học viên tối đa")]
        [ValidateCapacityGrade]
        [Required(ErrorMessage = "Cần phải có học viên tối đa")]
        public int Capacity { get; set; }

        [Display(Name = "Ngày thành lập")]
        [DataType(DataType.Date)]
        [CustomDateTime(ErrorMessage = "Ngày thành lập nhỏ hơn hoặc bằng ngày hiện tại")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Cần phải có ngày thành lập")]
        public DateTime Founded { get; set; }

        [Display(Name = "Người tạo")]
        [MaxLength(50, ErrorMessage = "Tên người tạo không được vượt quá 50 ký tự")]
        [Required(ErrorMessage = "Cần phải có người tạo")]
        public string? Creator { get; set; }

        public FacultyTable? Faculty { get; set; }
        [Display(Name = "Khoa")]
        // [Required(ErrorMessage = "Cần phải có khoa")]
        public Guid? FacultyId { get; set; }
        public ICollection<AppUser>? Students { get; set; }
    }
}
