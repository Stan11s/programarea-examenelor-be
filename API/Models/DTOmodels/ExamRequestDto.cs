namespace API.Models.DTOmodels
{
    public class ExamRequestDto
    {
        public string CourseName { get; set; }
        public string FirstNameProf { get; set; }
        public string LastNameProf { get; set; }
        public DateTime ExamDate { get;set; }
        public TimeSpan TimeStart { get; set; } 
        public string Status { get; set; }

    }
}
