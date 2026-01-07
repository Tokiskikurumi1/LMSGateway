using ADMIN_controller.DAL.Implement;
using ADMIN_controller.Models.respose;
using Microsoft.AspNetCore.Mvc;

namespace ADMIN_controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        private readonly DAL_RevenueTable _dal = new DAL_RevenueTable();

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _dal.GetAllRevenue();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Revenue_table model)
        {
            var success = _dal.CreateRevenue(model);
            if (success) return Ok("Thêm giao dịch thành công");
            return BadRequest("Thêm thất bại");
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Revenue_table model)
        {
            model.RevenueID = id;
            var success = _dal.UpdateRevenue(model);
            if (success) return Ok("Cập nhật giao dịch thành công");
            return BadRequest("Cập nhật thất bại");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _dal.DeleteRevenue(id);
            if (success) return Ok("Xóa giao dịch thành công");
            return BadRequest("Xóa thất bại");
        }
        [HttpGet("filter")]
        public IActionResult Filter(DateTime? fromDate, DateTime? toDate, string? status)
        {
            var data = _dal.GetAllRevenue();

            if (fromDate.HasValue)
                data = data.Where(r => r.PaymentDate >= fromDate.Value).ToList();

            if (toDate.HasValue)
                data = data.Where(r => r.PaymentDate <= toDate.Value).ToList();

            if (!string.IsNullOrWhiteSpace(status))
                data = data.Where(r => r.Status == status).ToList();

            return Ok(data);
        }

    }
}
