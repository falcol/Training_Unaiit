using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Training_Unaiit.Models.Faculty;
using Training_Unaiit.Models.School;
using Unaiit.Models;

namespace Training_Unaiit.CustomValidate
{
    public class ValidateCapacity : ValidationAttribute
    {
        protected readonly UnaiitDbContext _context;
        public ValidateCapacity(UnaiitDbContext context) : base("Data Source=localhost,1433;Initial Catalog=Unaiit;Persist Security Info=False;User ID=sa;Password=pass1234;Connection Timeout=30;")
        {
            _context = context;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var capacity_faculty = (FacultyTable)validationContext.ObjectInstance;
            var capacity_school_value = _context.School.FirstOrDefault(m => m.Id == capacity_faculty.SchoolId).Capacity;

            var all_capacity_faculty = _context.Faculty.Where(x => x.SchoolId == capacity_faculty.SchoolId).ToList() ?? new List<FacultyTable>();
            var sum_capacity_faculty = all_capacity_faculty.Sum(x => x.Capacity);
            var capacity_left = (capacity_school_value - sum_capacity_faculty);
            return capacity_faculty.Capacity > capacity_left ? new ValidationResult($"Trường chỉ còn đủ cho {Math.Abs((int)capacity_left)} học sinh") : ValidationResult.Success;
        }
    }
}
