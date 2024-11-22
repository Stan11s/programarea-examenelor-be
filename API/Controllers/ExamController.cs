using API.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ExamController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ExamController(ApiDbContext context)
        {
            _context = context;
        }
    }
}
