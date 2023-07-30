using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StudentRestApi.Model;

namespace StudentRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRespository studentRespository;

        public StudentController(IStudentRespository studentRespository)
        {
            this.studentRespository = studentRespository;
        }
        [Route("search")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Student>>> Search(string name, Gender? gender)
        {
            try
            {
               var result = await studentRespository.Search(name, gender);
                if(result.Any())
                {
                    return Ok(result);
                }
                return NotFound();

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Route("all")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                return Ok(await studentRespository.GetStudents());

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {   
               var result = await studentRespository.GetStudent(id);

                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                if(student == null)
                {
                    return BadRequest();
                }
               var result = await studentRespository.GetStudentByEmail(student.Email);
                if(result != null)
                {
                   
                    return BadRequest("Student already exist");
                }
                var createStudent = await studentRespository.AddStudent(student);
                return CreatedAtAction(nameof(GetStudent), new {id = createStudent.StudentId},createStudent);

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Student>> UpdateStudent(int id,Student student)
        {
            try
            {
                if(id != student.StudentId)
                {
                    return BadRequest();
                }
                var studentToUpdate = await studentRespository.GetStudent(id);
                if(studentToUpdate == null)
                {
                    return NotFound();
                }
                return await studentRespository.UpdateStudent(student);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
       
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
              var result =  await studentRespository.GetStudent(id);
                if(result == null)
                {
                    return NotFound();
                }
                await studentRespository.DeleteStudent(id);
                return Ok($"Student {id} has been deleted!");

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
