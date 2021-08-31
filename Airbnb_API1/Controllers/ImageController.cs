using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Airbnb_API1.Models;

namespace Airbnb_API1.Controllers
{
    public class ImageController : ApiController
    {
        private airbnbDB db = new airbnbDB();

        // GET: api/Image
        public IQueryable<Image> GetImages()
        {
            return db.Images;
        }
        [HttpGet]
        // GET: api/Image/5
        [ResponseType(typeof(Image))]
        public IHttpActionResult GetImage(int id)
        {
            airbnbDB ent = new airbnbDB();
            var d = (from i in ent.Images
                     where i.Loc_Id == id


                     select i.Image1).ToList();
            //Image image = db.Images.Find(id);
            if (d == null)
            {
                return NotFound();
            }

            return Ok(d);
        }

        // PUT: api/Image/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImage(int id, Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != image.Img_ID)
            {
                return BadRequest();
            }

            db.Entry(image).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
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

        // POST: api/Image
        [ResponseType(typeof(Image))]
        public IHttpActionResult PostImage(Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Images.Add(image);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ImageExists(image.Img_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = image.Img_ID }, image);
        }

        // DELETE: api/Image/5
        [ResponseType(typeof(Image))]
        public IHttpActionResult DeleteImage(int id)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return NotFound();
            }

            db.Images.Remove(image);
            db.SaveChanges();

            return Ok(image);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageExists(int id)
        {
            return db.Images.Count(e => e.Img_ID == id) > 0;
        }


        [Route("api/Image/saveimg")]
        public string saveimg()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/assets/" + filename);
                postedFile.SaveAs(physicalPath);
                

                return filename;
            }
            catch (Exception)
            {
                return "anonymous.png";
            }

        }
    }
}