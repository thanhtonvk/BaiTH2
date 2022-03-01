using BaiTH2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaiTH2.Controllers
{
    public class HangHoaController : ApiController
    {
        DBContext db = new DBContext();
        [HttpGet]
        [Route("api/hanghoa/hanghoabymaloai")]
        public IQueryable<HangHoa> GetHangHoaByMaLoai(int ID)
        {
            return db.HangHoas.Where(x => x.MaLoai == ID);
        }
        [HttpGet]
        [Route("api/hanghoa/hanghoabytenloai")]
        public IQueryable<HangHoa> GetHangHoaByTenLoai(string TenLoai)
        {
            return db.HangHoas.Where(x => x.LoaiHang.TenLoai == TenLoai);
        }
        [HttpGet]
        [Route("api/hanghoa/hanghoasaphet")]
        public IQueryable<HangHoa> GetHangHoaSapHet(string TenLoai)
        {
            return db.HangHoas.Where(x => x.SoLuongCon < 5);
        }
        [HttpGet]
        [Route("api/hanghoa/getgiaban")]
        public IHttpActionResult GetThongTinHang(int mahang)
        {
            var datenow = DateTime.Now.ToString("dd-MM-yyyy");
            var giaban = db.HangHoas.Find(mahang).GiaBans.Where(x => x.NgayDB.ToString() == datenow).FirstOrDefault().Gia;
            return Ok("Gia la" + giaban);
        }
        [HttpGet]
        [Route("api/hanghoa/getgiaminmax")]
        public IEnumerable<HangHoa> GetGiaMinMax(int min, int max)
        {
            List<HangHoa> hangHoas = new List<HangHoa>();
            var datenow = DateTime.Now.ToString("dd-MM-yyyy");
            var model = db.GiaBans.Where(x => x.Gia >= min && x.Gia <= max&&x.NgayDB.ToString()==datenow);
            foreach(var item in model)
            {
                hangHoas.Add(item.HangHoa);
            }
            return hangHoas.ToList();
        }
        [HttpGet]
        [Route("api/hanghoa/getgiabanbymahang")]
        public IEnumerable<GiaBan> GetGiaBanByMaHang(int ID)
        {
            return db.HangHoas.Find(ID).GiaBans;
        }
        [HttpPut]
        [Route("api/hanghoa/suagiaban")]
        public IHttpActionResult SuaGiaBan(int IDHangHoa,GiaBan giaBan)
        {
            var model = db.GiaBans.FirstOrDefault(x => x.MaHang == IDHangHoa);
            if (model == null) return NotFound();
            else
            {
                db.GiaBans.Add(giaBan);
                db.Entry(giaBan).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Ok("Thành công");
            }
        }
        [HttpDelete]
        [Route("api/hanghoa/xoagiaban")]
        public IHttpActionResult XoaGiaBan(int IDHangHoa)
        {
            var model = db.HangHoas.FirstOrDefault(x => x.MaHang == IDHangHoa);
            if (model == null) return NotFound();
            else
            {
                db.GiaBans.RemoveRange(model.GiaBans);
                db.SaveChanges();
                return Ok("Thành công");
            }
        }
        [HttpGet]
        [Route("api/hanghoa/gethanghoabymahang")]
        public IHttpActionResult GetHangHoaByMaHang(int IDHangHoa)
        {
            var datenow = DateTime.Now.ToString("dd-MM-yyyy");
            var model = db.HangHoas.Find(IDHangHoa);
            var giaban = model.GiaBans.Where(x => x.NgayDB.ToString() == datenow).ToList();
            model.GiaBans = giaban;
            return Ok(model);
        }
        [HttpPost]
        [Route("api/hanghoa/themhanghoa")]
        public IHttpActionResult AddHangHoa([FromBody] HangHoa hangHoa)
        {
            db.HangHoas.Add(hangHoa);
            if (db.SaveChanges() > 0)
            {
                return Ok("Thanh cong");
            }
            return BadRequest("Khong thanh cong");
        }
        [HttpPut]
        [Route("api/hanghoa/suahanghoa")]
        public IHttpActionResult PutHangHoa([FromBody] HangHoa hangHoa)
        {
            db.HangHoas.Add(hangHoa);
            db.Entry(hangHoa).State = System.Data.Entity.EntityState.Modified;
            if (db.SaveChanges() > 0) return Ok("thanh cong");
            return BadRequest("Loi");
        }
        [HttpDelete]
        [Route("api/hanghoa/xoahanghoa")]
        public IHttpActionResult DeleteHangHoa(int ID)
        {
            var model = db.HangHoas.Find(ID);
            db.HangHoas.Remove(model);
            if (db.SaveChanges() > 0) return Ok("thanh cong");
            return BadRequest("Loi");
        }

    }
}
