using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Training_Unaiit.Models.Faculty;
using Unaiit.Models;

namespace Training_Unaiit.Models.School
{
    [Table("School")]
    public class SchoolTable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Cần phải có tên trường")]
        [Display(Name = "Tên trường")]
        [StringLength(100, ErrorMessage = "Tên trường không được vượt quá 100 ký tự")]
        public string Name { get; set; } = default!;

        [Required(ErrorMessage = "Cần phải có địa chỉ")]
        [Display(Name = "Địa chỉ")]
        [StringLength(250, ErrorMessage = "Địa chỉ không được vượt quá 250 ký tự")]
        public string Address { get; set; } = default!;

        [Required(ErrorMessage = "Cần phải có ngày thành lập")]
        [Display(Name = "Ngày thành lập")]
        [DataType(DataType.Date)]
        public DateTime Founded { get; set; }

        [Display(Name = "Số lượng học viên tối đa")]
        [Range(0, 1000, ErrorMessage = "Số lượng học viên tối đa nhỏ hơn 10000")]
        public int Capacity { get; set; }

        public ICollection<FacultyTable> Faculties { get; set; } = default!;
        public ICollection<AppUser> Students { get; set; } = default!;

    }
}
