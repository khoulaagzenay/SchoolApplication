namespace SchoolApplication.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string Observation { get; set; } = string.Empty;
        public double Value { get; set; }

        //clef etrangère (student)
        public int StudentId { get; set; }
        // propriété de navigation pour les students
        public Student? Student { get; set; }
        // clef etrangère (course)
        public int CourseId { get; set; }
        // propriété de navigation pour les course
        public Course? Course { get; set; }
    }
}
