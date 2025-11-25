using System.Collections.Generic;

namespace StudentCoursesApp.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Grade { get; set; } = string.Empty;

        // Navigation properties
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}