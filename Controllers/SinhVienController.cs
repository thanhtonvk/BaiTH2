using System;
using System.Linq;
using System.Web.Http;
using BaiTH2.Models;

namespace BaiTH2.Controllers
{
    public class SinhVienController : ApiController
    {
        private DBContext db = new DBContext();

        [HttpGet]
        [Route("api/sinhvien/getsvbydiachi")]
        public IHttpActionResult GetSVByDiaChi(string diachi)
        {
            return Ok(db.SinhViens.Where(x => x.DiaChi == diachi));
        }

        [HttpGet]
        [Route("api/sinhvien/getsvbyten")]
        public IHttpActionResult GetSVByTen(string ten)
        {
            return Ok(db.SinhViens.Where(x => x.TenSV == ten));
        }

        [HttpGet]
        [Route("api/sinhvien/getsvbyyear")]
        public IHttpActionResult GetSVByYear()
        {
            var year = DateTime.Now.Year;
            return Ok(db.SinhViens.Where(x => year - Year(x.NgaySinh.ToString()) > 20));
        }

        private int Year(string ngaysinh)
        {
            return int.Parse(ngaysinh.Split('-')[0]);
        }
    }
}