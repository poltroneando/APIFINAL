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
    public class FilmesController : ApiController
    {
        private FilmesContext db = new FilmesContext();
        
        /// <summary>
        /// Utilizado para retornar a lista de filmes já incluidos
        /// </summary>
        /// <returns>Retorna a lista de filmes</returns>
        // GET: api/Filmes
        public IQueryable<Filmes> GetFilmes()
        {
            return db.Filmes;
        }
        /// <summary>
        /// Utilizado para retornar um registro de Filme da lista apartir do id
        /// </summary>
        /// <param name="id">Identificador dos filmes</param>
        /// <returns>Retorna o Filme</returns>
        // GET: api/Filmes/5
        [ResponseType(typeof(Filmes))]      

        public IHttpActionResult GetFilmes(int id)
        {
            Filmes filmes = db.Filmes.Find(id);
            if (filmes == null)
            {
                return NotFound();
            }

            return Ok(filmes);
        }
        /// <summary>
        /// Altera um registro de filme dentro da lista
        /// </summary>
        /// <param name="id">Identificador dos filmes</param>
        /// <param name="filmes">Lista onde estão os registros</param>
        /// <returns>Retorna o registro alterado</returns>
        // PUT: api/Filmes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFilmes(int id, Filmes filmes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filmes.Id)
            {
                return BadRequest();
            }

            db.Entry(filmes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmesExists(id))
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
        /// <param name="filmes">Lista de registros</param>
        /// <returns>Retorna a lista atualizada</returns>
        // POST: api/Filmes
        [ResponseType(typeof(Filmes))]
        public IHttpActionResult PostFilmes(Filmes filmes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Filmes.Add(filmes);
            db.SaveChanges();

            return CreatedAtRoute("PoltronandoAPI", new { id = filmes.Id }, filmes);
        }
        /// <summary>
        /// Exclui um registro da lista
        /// </summary>
        /// <param name="id">Identificador dos filmes</param>
        /// <returns>Retorna lista atualizada</returns>
        // DELETE: api/Filmes/5
        [ResponseType(typeof(Filmes))]
        public IHttpActionResult DeleteFilmes(int id)
        {
            Filmes filmes = db.Filmes.Find(id);
            if (filmes == null)
            {
                return NotFound();
            }

            db.Filmes.Remove(filmes);
            db.SaveChanges();

            return Ok(filmes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilmesExists(int id)
        {
            return db.Filmes.Count(e => e.Id == id) > 0;
        }
    }
}