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
using APIFINAL.Models;

namespace APIFINAL.Controllers
{
    public class CelebridadesController : ApiController
    {
        private CelebridadesContext db = new CelebridadesContext();

        /// <summary>
        /// Utilizado para retornar a lista de Celebridades já incluidas
        /// </summary>
        /// <returns>Retorna a lista de Celebridades</returns>
        // GET: api/Celebridades
        public IQueryable<Celebridades> GetCelebridades()
        {
            return db.Celebridades;
        }
        /// <summary>
        /// Utilizado para retornar um registro de Celebridade da lista apartir do id
        /// </summary>
        /// <param name="id">Identificador das Celebridades</param>
        /// <returns>Retorna a Celebridade</returns>
        // GET: api/Celebridades/5
        [ResponseType(typeof(Celebridades))]
        public IHttpActionResult GetCelebridades(int id)
        {
            Celebridades celebridades = db.Celebridades.Find(id);
            if (celebridades == null)
            {
                return NotFound();
            }

            return Ok(celebridades);
        }

        /// <summary>
        /// Altera um registro de Celebridade dentro da lista
        /// </summary>
        /// <param name="id">Identificador das Celebridades\</param>
        /// <param name="celebridades">Lista onde estão os registros</param>
        /// <returns>Retorna o registro alterado</returns>
        // PUT: api/Celebridades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCelebridades(int id, Celebridades celebridades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != celebridades.Id)
            {
                return BadRequest();
            }

            db.Entry(celebridades).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CelebridadesExists(id))
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

        /// <summary>
        /// Inclui um registo na lista
        /// </summary>
        /// <param name="celebridades">Lista de registros</param>
        /// <returns>Retorna a lista atualizada</returns>
        // POST: api/Celebridades
        [ResponseType(typeof(Celebridades))]
        public IHttpActionResult PostCelebridades(Celebridades celebridades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Celebridades.Add(celebridades);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = celebridades.Id }, celebridades);
        }

        /// <summary>
        /// Exclui um registro da lista
        /// </summary>
        /// <param name="id">Identificador das Celebridades</param>
        /// <returns>Retorna lista atualizada</returns>
        // DELETE: api/Celebridades/5
        [ResponseType(typeof(Celebridades))]
        public IHttpActionResult DeleteCelebridades(int id)
        {
            Celebridades celebridades = db.Celebridades.Find(id);
            if (celebridades == null)
            {
                return NotFound();
            }

            db.Celebridades.Remove(celebridades);
            db.SaveChanges();

            return Ok(celebridades);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CelebridadesExists(int id)
        {
            return db.Celebridades.Count(e => e.Id == id) > 0;
        }
    }
}