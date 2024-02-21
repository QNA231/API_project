using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThemSuaXoaDuLieu.Constant;
using ThemSuaXoaDuLieu.Entities;
using ThemSuaXoaDuLieu.IServices;
using ThemSuaXoaDuLieu.Services;

namespace ThemSuaXoaDuLieu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonServices hoaDonServices;

        public HoaDonController()
        {
            hoaDonServices = new HoaDonServices();
        }

        [HttpGet]
        public IActionResult LayHoaDon(string? keyword, int? year = null, int? month = null, DateTime? tuNgay = null, DateTime? denNgay = null, int? giaTu = null, int? giaDen = null,[FromQuery] Pagination? pagination = null)
        {
            var query = hoaDonServices.LayHoaDon(keyword, year, month, tuNgay, denNgay, giaTu, giaDen);
            var hoaDons = PageResult<HoaDon>.ToPageResult(pagination, query).AsEnumerable();
            pagination.TotalCount = hoaDons.Count();
            var res = new PageResult<HoaDon>(pagination, hoaDons);
            return Ok(res);
        }

        [HttpPost("themHoaDonChoKhachHang")]
        public IActionResult ThemHoaDon([FromBody] HoaDon hoaDon)
        {
            var ret = hoaDonServices.ThemHoaDon(hoaDon);
            if(ret == ErrorMessage.ThanhCong)
            {
                return Ok("Them thanh cong");
            }
            else
            {
                return BadRequest("Them that bai");
            }
        }
        //checked

        [HttpPut("capNhatHoaDon")]
        public IActionResult CapNhatHoaDon([FromBody] HoaDon hoaDon)
        {
            var ret = hoaDonServices.SuaHoaDon(hoaDon);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Cap nhat thanh cong");
            }
            else
            {
                return BadRequest("Cap nhat that bai");
            }
        }
        //checked

        [HttpDelete("xoaHoaDon")]
        public IActionResult XoaHoaDon([FromQuery] int hoaDonId)
        {
            var ret = hoaDonServices.XoaHoaDon(hoaDonId);
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
