using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookingSystem.Models
{
    public class StudentCourseViewModel
    {
        public List<Student> students;
        public SelectList courses;
        public SelectList paid;
        public string studentCourse { get; set; }

        public bool hasPaid { get; set; }
        
    }
}