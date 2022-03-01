using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using BaiTH2.Models;

namespace BaiTH2.Controllers
{
    public class NhanVienController : ApiController
    {
        private DBContext db = new DBContext();

        [HttpGet]
        [Route("api/nhanvien/getnhanvienbyname")]
        public IHttpActionResult GetNhanVienByName(string TenNV)
        {
            var model = db.NhanViens.Where(x => x.TenNV.Equals(TenNV));
            if (model.Any())
            {
                return Ok(model);
            }

            return BadRequest("Khong tim thay");
        }

        [HttpGet]
        [Route("api/nhanvien/getnhanvienbynamephone")]
        public IHttpActionResult GetNhanVienByNamePhone(string TenNV, string Phone)
        {
            var model = db.NhanViens.Where(x => x.TenNV.Equals(TenNV) && x.SDT == Phone);
            if (model.Any())
            {
                return Ok(model);
            }

            return BadRequest("Khong tim thay");
        }

        [HttpGet]
        [Route("api/nhanvien/getnhanvienbynamephonesex")]
        public IHttpActionResult GetNhanVienByNamePhoneSex(string TenNV, string Phone, string Sex)
        {
            var model = db.NhanViens.Where(x => x.TenNV.Equals(TenNV) && x.SDT == Phone && x.GioiTinh == Sex);
            if (model.Any())
            {
                return Ok(model);
            }

            return BadRequest("Khong tim thay");
        }

        [HttpPut]
        [Route("api/nhanvien/putnhanvien")]
        public IHttpActionResult PutNhanVien([FromBody] NhanVien nhanVien)
        {
            if (IsExists(nhanVien.MaNV))
            {
                db.NhanViens.Add(nhanVien);
                db.Entry(nhanVien).State = EntityState.Modified;
                if (db.SaveChanges() > 0) return Ok("Thanh cong");
                return BadRequest("Loi");
            }

            return BadRequest("Khong ton tai tai khoan");
        }

        public bool IsExists(string MaNV)
        {
            var model = db.NhanViens.Find(MaNV);
            if (model == null) return false;
            return true;
        }
    }
}