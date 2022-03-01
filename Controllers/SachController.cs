using System;
using System.Linq;
using System.Web.Http;
using BaiTH2.Models;

namespace BaiTH2.Controllers
{
    public class SachController : ApiController
    {
        private DBContext db = new DBContext();

        [HttpGet]
        [Route("api/sach/getsachbyname")]
        public IHttpActionResult GetSachByName(string Name)
        {
            var model = db.Saches.Where(x => x.TenSach == Name);
            if (model.Any())
            {
                return Ok(model);
            }

            return BadRequest("Khong tim thay");
        }

        [HttpGet]
        [Route("api/sach/getsachbytacgia")]
        public IHttpActionResult GetSachByTacGia(string Tacgia)
        {
            var model = db.Saches.Where(x => x.TacGia == Tacgia);
            if (model.Any())
            {
                return Ok(model);
            }

            return BadRequest("Khong tim thay");
        }

        [HttpGet]
        [Route("api/sach/getsachbynxb")]
        public IHttpActionResult GetSachByNXB(string NXB)
        {
            var model = db.Saches.Where(x => x.NhaXB == NXB);
            if (model.Any())
            {
                return Ok(model);
            }

            return BadRequest("Khong tim thay");
        }

        [HttpGet]
        [Route("api/sach/getsachbyyear")]
        public IHttpActionResult GetSachByYear()
        {
            var yearnow = DateTime.Now.Year;
            var model = db.Saches.Where(x => (yearnow - x.NamXB) <= 5);
            if (model.Any())
            {
                return Ok(model);
            }

            return BadRequest("Khong tim thay");
        }
    }
}