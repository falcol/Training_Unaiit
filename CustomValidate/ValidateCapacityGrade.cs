using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NuGet.Protocol;
using Training_Unaiit.Models.Faculty;
using Training_Unaiit.Models.Grade;
using Training_Unaiit.Models.School;
using Unaiit.Models;

namespace Training_Unaiit.CustomValidate
{
    public class ValidateCapacityGrade : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var grade_faculty = (GradeTable)validationContext.ObjectInstance;
            var _context = (UnaiitDbContext?)validationContext?.GetService(typeof(UnaiitDbContext));
            var capacity_faculty_value = _context?.Faculty?.FirstOrDefault(m => m.Id == grade_faculty.FacultyId)?.Capacity;
            Console.WriteLine("GRADE: " + capacity_faculty_value.ToJson());
            if (capacity_faculty_value == null)
                capacity_faculty_value = 0;

            var all_capacity_faculty = _context?.Grade.Where(x => x.FacultyId == grade_faculty.FacultyId).ToList() ?? new List<GradeTable>();
            var sum_capacity_faculty = all_capacity_faculty.Sum(x => x.Capacity);
            Console.WriteLine("CAPACITY2: " + sum_capacity_faculty);
            var capacity_left = capacity_faculty_value - sum_capacity_faculty;
            if (capacity_left >= 0){
                return (grade_faculty?.Capacity > capacity_left) ? new ValidationResult($"Khối còn đủ cho {(int)capacity_left} học sinh") : ValidationResult.Success;
            } else {
                return new ValidationResult("Khối đã đủ học sinh");
            }
        }
    }
}
