using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Student> Post(CreateStudentDto createStudentDto)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Name = createStudentDto.Name,
                Age = createStudentDto.Age,
                Email = createStudentDto.Email,
                CreatedTime = DateTime.Now
            };
            if (student != null)
            {
                using (var context = new LibraryContext())
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                    return StatusCode(201, student);
                }
            }
            return BadRequest();
        }
    }
}
