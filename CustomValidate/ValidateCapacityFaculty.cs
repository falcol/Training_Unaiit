using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NuGet.Protocol;
using Training_Unaiit.Models.Faculty;
using Training_Unaiit.Models.School;
using Unaiit.Models;

namespace Training_Unaiit.CustomValidate
{
    public class ValidateCapacityFaculty : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var capacity_faculty = (FacultyTable)validationContext.ObjectInstance;
            var _context = (UnaiitDbContext?)validationContext?.GetService(typeof(UnaiitDbContext));
            if (_context.Faculty.FirstOrDefault(m => m.Id == capacity_faculty.Id) != null){
                return ValidationResult.Success;
            }
            if (capacity_faculty.SchoolId == null){
                return new ValidationResult("Bạn chưa chọn trường");
            }
            var capacity_school_value = _context?.School?.FirstOrDefault(m => m.Id == capacity_faculty.SchoolId)?.Capacity;

            var all_capacity_faculty = _context?.Faculty.Where(x => x.SchoolId == capacity_faculty.SchoolId).ToList() ?? new List<FacultyTable>();
            var sum_capacity_faculty = all_capacity_faculty.Sum(x => x.Capacity);
            Console.WriteLine("CAPACITY: " + sum_capacity_faculty);
            var capacity_left = capacity_school_value - sum_capacity_faculty;
            if (capacity_left > 0){
                return (capacity_faculty?.Capacity > capacity_left) ? new ValidationResult($"Trường còn đủ cho {(int)capacity_left} học sinh") : ValidationResult.Success;
            } else {
                return new ValidationResult("Trường đã đủ học sinh");
            }
        }
    }
}
