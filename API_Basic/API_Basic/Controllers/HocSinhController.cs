using API_Basic.Constant;
using API_Basic.Entities;
using API_Basic.IServices;
using API_Basic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Basic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocSinhController : ControllerBase
    {
        private readonly IHocSinhServices hocSinhServices;

        public HocSinhController()
        {
            hocSinhServices = new HocSinhServices();
        }

        [HttpGet]
        public IActionResult GetDsHocSinh([FromQuery] string? keyword, [FromQuery] Pagination pagination)
        {
            var dsHocSinh = hocSinhServices.GetDanhSachHocSinh(keyword, pagination);
            return Ok(dsHocSinh);
        }

        [HttpPost("themHocSinhVaoLop")]
        public IActionResult ThemHocSinh([FromBody] HocSinh hocSinh)
        {
            var ret = hocSinhServices.ThemHocSinh(hocSinh, hocSinh.LopId);
            if(ret == ErrorMessage.ThanhCong)
            {
                return Ok("Them thanh cong");
            }
            else
            {
                return BadRequest("Them that bai");
            }
        }

        [HttpPut("capNhatThongTinHocSinh")]
        public IActionResult CapNhatThongTinHocSinh([FromQuery] int hocSinhId)
        {
            var ret = hocSinhServices.SuaHocSinh(hocSinhId);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Cap nhat thanh cong");
            }
            else
            {
                return BadRequest("Cap nhat that bai");
            }
        }

        [HttpDelete("xoaHocSinh")]
        public IActionResult XoaHocSinh([FromQuery] int hocSinhId)
        {
            var ret = hocSinhServices.XoaHocSinh(hocSinhId);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Xoa thanh cong");
            }
            else
            {
                return BadRequest("Xoa that bai");
            }
        }
    }
}
