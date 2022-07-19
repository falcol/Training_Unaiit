using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Training_Unaiit.Models.Faculty;
using Unaiit.Models;

namespace Training_Unaiit.Models.Grade
{
    [Table("Grade")]
    public class GradeTable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Cần phải có tên lớp")]
        [Display(Name = "Tên lớp")]
        [MaxLength(50, ErrorMessage = "Tên lớp không được vượt quá 50 ký tự")]
        public string Name { get; set; } = default!;

        [Display(Name = "Học viên tối đa")]
        public int Capacity { get; set; }

        [Display(Name = "Ngày thành lập")]
        [DataType(DataType.Date)]
        public DateTime Founded { get; set; }

        [Display(Name = "Người tạo")]
        [MaxLength(50, ErrorMessage = "Tên người tạo không được vượt quá 50 ký tự")]
        public string Creator { get; set; } = default!;

        public ICollection<AppUser> Students { get; set; } = default!;
        public FacultyTable? Faculty { get; set; } = default!;
    }
}
