using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training_Unaiit.CustomValidate;
using Training_Unaiit.Migrations;
using Training_Unaiit.Models.Grade;
using Training_Unaiit.Models.School;
using Unaiit.Models;

namespace Training_Unaiit.Models.Faculty
{
    public class FacultyTable
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Cần phải có tên khoa")]
        [Display(Name = "Tên khoa")]
        [StringLength(100, ErrorMessage = "Tên khoa không được vượt quá 100 ký tự")]
        public string? Name { get; set; }

        [Display(Name = "Học viên tối đa")]
        [ValidateCapacityFaculty]
        // [Range(0, 200, ErrorMessage = "Học viên tối đa là 200")]
        [Required(ErrorMessage = "Cần phải có học viên tối đa")]
        public int Capacity { get; set; }

        [Display(Name = "Ngày thành lập")]
        [DataType(DataType.Date)]
        [CustomDateTime(ErrorMessage = "Ngày thành lập nhỏ hơn hoặc bằng ngày hiện tại")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Cần phải có ngày thành lập")]
        public DateTime Founded { get; set; }

        [Display(Name = "Người tạo")]
        [StringLength(100, ErrorMessage = "Tên người tạo không được vượt quá 100 ký tự")]
        [Required(ErrorMessage = "Cần phải có tên người tạo")]
        public string? Creator { get; set; }

        public SchoolTable? School { get; set; }

        [Display(Name = "Trường")]
        public Guid? SchoolId { get; set; }
    }
}
