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
        public IActionResult GetDsHoaDon()
        {
            var dsHoaDon = hoaDonServices.GetDsHoaDon();
            return Ok(dsHoaDon);
        }
        //Checked

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
