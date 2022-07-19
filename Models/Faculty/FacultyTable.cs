using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training_Unaiit.Models.Grade;
using Training_Unaiit.Models.School;

namespace Training_Unaiit.Models.Faculty
{
    public class FacultyTable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Cần phải có tên khoa")]
        [Display(Name = "Tên khoa")]
        [StringLength(100, ErrorMessage = "Tên khoa không được vượt quá 100 ký tự")]
        public string Name { get; set; } = default!;

        [Display(Name = "Học viên tối đa")]
        [Range(0, 200, ErrorMessage = "Học viên tối đa là 2000")]
        public int Capacity { get; set; }

        [Display(Name = "Ngày thành lập")]
        [DataType(DataType.Date)]
        public DateTime Founded { get; set; }

        [Display(Name = "Người tạo")]
        [StringLength(100, ErrorMessage = "Tên người tạo không được vượt quá 100 ký tự")]
        public string Creator { get; set; } = default!;

        public ICollection<GradeTable> Classes { get; set; } = default!;
        public SchoolTable? School { get; set; } = default!;
    }
}
