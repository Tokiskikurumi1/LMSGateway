using Microsoft.AspNetCore.Mvc;
using QLY_LMS.DAL.Admin.Implementations;
using QLY_LMS.Modal;

namespace ADMIN_controller.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly DAL_CourseTable _dal;

        public CourseController()
        {
            _dal = new DAL_CourseTable();
        }

        // GET api/course
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _dal.GetAllCourses();
            return Ok(list);
        }

        // GET api/course/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var course = _dal.GetCourseById(id);
            if (course == null) return NotFound(new { message = "Không tìm thấy khóa học" });
            return Ok(course);
        }

        // POST api/course
        [HttpPost]
        public IActionResult Create([FromBody] Course_table model)
        {
            var success = _dal.CreateCourse(model);
            if (success) return Ok(new { message = "Thêm khóa học thành công" });
            return BadRequest(new { error = "Thêm khóa học thất bại" });
        }

        // PUT api/course/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Course_table model)
        {
            model.CourseID = id;
            var success = _dal.UpdateCourse(model);
            if (success) return Ok(new { message = "Cập nhật khóa học thành công" });
            return BadRequest(new { error = "Cập nhật thất bại" });
        }

        // DELETE api/course/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _dal.DeleteCourse(id);
            if (success) return Ok(new { message = "Xóa khóa học thành công" });
            return BadRequest(new { error = "Xóa thất bại" });
        }
    }
}
