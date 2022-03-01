using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BaiTH2.Models;

namespace BaiTH2.Controllers
{
    public class DanhMucController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/DanhMuc
        public IQueryable<DanhMuc> GetDanhMucs()
        {
            return db.DanhMucs;
        }

        // GET: api/DanhMuc/5
        [ResponseType(typeof(DanhMuc))]
        public IHttpActionResult GetDanhMuc(int id)
        {
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return NotFound();
            }

            return Ok(danhMuc);
        }

        // PUT: api/DanhMuc/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDanhMuc(int id, DanhMuc danhMuc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != danhMuc.MaDanhMuc)
            {
                return BadRequest();
            }

            db.Entry(danhMuc).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanhMucExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DanhMuc
        [ResponseType(typeof(DanhMuc))]
        public IHttpActionResult PostDanhMuc(DanhMuc danhMuc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DanhMucs.Add(danhMuc);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = danhMuc.MaDanhMuc }, danhMuc);
        }

        // DELETE: api/DanhMuc/5
        [ResponseType(typeof(DanhMuc))]
        public IHttpActionResult DeleteDanhMuc(int id)
        {
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return NotFound();
            }

            db.DanhMucs.Remove(danhMuc);
            db.SaveChanges();

            return Ok(danhMuc);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DanhMucExists(int id)
        {
            return db.DanhMucs.Count(e => e.MaDanhMuc == id) > 0;
        }
    }
}