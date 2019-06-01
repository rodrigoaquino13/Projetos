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
using App_Empresas.Models.Context;
using App_Empresas.Models.Entities;

namespace App_Empresas.Controllers
{
    public class EmpresasController : ApiController
    {
        private EmpresasContext db = new EmpresasContext();

        // GET: api/Empresas1
        public IQueryable<Empresas> GetEmpresas()
        {
            return db.Empresas;
        }

        // GET: api/Empresas1/5
        [ResponseType(typeof(Empresas))]
        public IHttpActionResult GetEmpresas(int id)
        {
            Empresas empresas = db.Empresas.Find(id);
            if (empresas == null)
            {
                return NotFound();
            }

            return Ok(empresas);
        }

        // PUT: api/Empresas1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpresas(int id, Empresas empresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empresas.Codigo)
            {
                return BadRequest();
            }

            db.Entry(empresas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresasExists(id))
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

        // POST: api/Empresas1
        [ResponseType(typeof(Empresas))]
        public IHttpActionResult PostEmpresas(Empresas empresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empresas.Add(empresas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empresas.Codigo }, empresas);
        }

        // DELETE: api/Empresas1/5
        [ResponseType(typeof(Empresas))]
        public IHttpActionResult DeleteEmpresas(int id)
        {
            Empresas empresas = db.Empresas.Find(id);
            if (empresas == null)
            {
                return NotFound();
            }

            db.Empresas.Remove(empresas);
            db.SaveChanges();

            return Ok(empresas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpresasExists(int id)
        {
            return db.Empresas.Count(e => e.Codigo == id) > 0;
        }
    }
}