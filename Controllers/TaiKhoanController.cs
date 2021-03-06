using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BaiTH2.Models;

namespace BaiTH2.Controllers
{
    public class TaiKhoanController : ApiController
    {
        private DBContext db = new DBContext();
        [HttpGet]
        [Route("api/taikhoan/gettaikhoans")]
        public IQueryable<TaiKhoan> GetTaiKhoan()
        {
            return db.TaiKhoans;
        }
        [HttpGet]
        [Route("api/taikhoan/GetTaiKhoan")]
        public IHttpActionResult GetTaiKhoan(string TenTK)
        {
            var model = db.TaiKhoans.Find(TenTK);
            if (model != null)
            {
                return Ok(model);
            }

            return null;
        }
        [HttpPost]
        [Route("api/taikhoan/posttaikhoan")]
        public IHttpActionResult PostTaiKhoan([FromBody] TaiKhoan taiKhoan)
        {
            db.TaiKhoans.Add(taiKhoan);
            if (db.SaveChanges() > 0)
            {
                return Ok("thanh cong");
            }

            return NotFound();
        }
        [HttpPut]
        [Route("api/taikhoan/puttaikhoan")]
        public IHttpActionResult PutTaiKhoan([FromBody] TaiKhoan taiKhoan)
        {
            if (IsExists(taiKhoan.TenTK))
            {
                db.TaiKhoans.Add(taiKhoan);
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return Ok("Thanh cong");
            }

            return BadRequest("Tai khoan khong ton tai");
        }
        [HttpDelete]
        [Route("api/taikhoan/deletetaikhoan")]
        public IHttpActionResult DeleteTaiKhoan(string TenTK)
        {
            if (IsExists(TenTK))
            {
                var model = db.TaiKhoans.Find(TenTK);
                db.TaiKhoans.Remove(model);
                db.SaveChanges();
                return Ok("Thanh cong");
            }

            return BadRequest("Tai khoan khong ton tai");
        }

        public bool IsExists(string TenTK)
        {
            var model = db.TaiKhoans.Find(TenTK);
            if (model == null) return false;
            return true;
        }
    }
}