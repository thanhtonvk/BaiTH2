using BaiTH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaiTH2.Controllers
{
    public class SanPhamController : ApiController
    {
        DBContext db = new DBContext();
        [HttpGet]
        [Route("api/sanpham/getsanphams")]
        public IQueryable<SanPham> GetSanPham()
        {
            return db.SanPhams;
        }
        [HttpGet]
        [Route("api/sanpham/GetSanPham")]
        public IHttpActionResult GetSanPham(int ID)
        {
            var model = db.SanPhams.Find(ID);
            if (model == null) return BadRequest("Khong tim thay");
            return Ok(model);
        }
        [HttpPost]
        [Route("api/sanpham/postsanpham")]
        public IHttpActionResult PostSanPham([FromBody] SanPham sanPham)
        {
            db.SanPhams.Add(sanPham);
            if (db.SaveChanges()>0)
            {
                return Ok("Thanh cong");
            }
            return BadRequest("Loi");
        }
        [HttpPut]
        [Route("api/sanpham/putsanpham")]
        public IHttpActionResult PutSanPham([FromBody] SanPham sanPham)
        {
            if (IsExist(sanPham.Ma))
            {
                db.SanPhams.Add(sanPham);
                db.Entry(sanPham).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    return Ok("Thanh cong");
                }
                return BadRequest("Loi");
            }
            return BadRequest("Khong ton tai");
        }
        [HttpDelete]
        [Route("api/sanpham/DeleteSanPham")]
        public IHttpActionResult DeleteSanPham(int ID)
        {
            var model = db.SanPhams.Find(ID);
            if (model == null) return BadRequest("Khong ton tai");
            else
            {
                db.SanPhams.Remove(model);
                db.SaveChanges();
                return Ok("Thanh cong");
            }
        }
        public bool IsExist(int ID)
        {
            var model = db.SanPhams.Find(ID);
            if (model == null) return false;
            return true;
        }

    }
}
