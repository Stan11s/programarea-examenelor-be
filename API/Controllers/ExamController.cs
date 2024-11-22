using API.Data;
using API.Enum;
using API.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers
{
    public class ExamController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly CourseMapper _courseMapper;  

        // Constructor
        public ExamController(ApiDbContext context, CourseMapper courseMapper)
        {
            _context = context;
            _courseMapper = courseMapper;
        }

        [HttpGet("GetCoursersForExamByUserID")]
        public async Task<IActionResult> GetCoursersForExamByUserID(int userId)
        {
            
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            if(user.Status== StatusUserEnum.Student)
            {
                var student = await _context.Students
                .Include(s => s.Group)
                .ThenInclude(g => g.Specialization)
                .FirstOrDefaultAsync(s => s.UserID == userId);

                if (student == null)
                {
                    return NotFound("Student not found");
                }

                var specializationId = student.Group.SpecializationID;

                var courses = await _context.Courses
                    .Where(c => c.SpecializationID == specializationId)
                    .Include(c => c.Professor)
                    .ThenInclude(c => c.User)
                    .ToListAsync();

                if (courses == null || !courses.Any())
                {
                    return NotFound("No courses found for this student.");
                }

                var courseDTOs = courses.Select(course => _courseMapper.MapToCourseDTO(course)).ToList(); // Use _courseMapper

                return Ok(courseDTOs);
            }
            else
            {
                return BadRequest("Invalid role.");
            }
        }
    }
}