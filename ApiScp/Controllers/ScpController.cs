using ApiScp.Context;
using ApiScp.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiScp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScpController : ControllerBase
    {

        private readonly AppDbContext _context;
        public ScpController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<ScpController>
        [HttpGet]
        public ActionResult<List<Scp>> Get()
        {
            var scp_items = _context.Scps.ToList();

            if (scp_items.Count == 0 || scp_items is null)
            {
                return NoContent();
            }

            return Ok(scp_items);
        }

        // GET api/<ScpController>/5
        [HttpGet("{scpItem}")]
        public ActionResult<Scp> Get(string scpItem)
        {
            var scp = _context.Scps.FirstOrDefault(s => s.ItemNumber == scpItem);

            return Ok(scp);

        }

        //POST api/<ScpController>
        [HttpPost]
        public ActionResult Post(Scp scp)
        {

            if (scp == null)
            {
                return BadRequest();
            }

            //enviando ele para o banco
            _context.Scps.Add(scp);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/<ScpController>/5
        //[HttpPut("{id}")]
        //public ActionResult Put(int id, [FromBody] Scp spc)
        //{
        //    var ScpNotUpdated = _context.Scps.SingleOrDefault(i => i.Id == id);
        //    if (ScpNotUpdated == null)
        //    {
        //        return NoContent();
        //    }
        //    ScpNotUpdated.UpdateScp();


        //    return Ok(ScpNotUpdated);
        //}

        // DELETE api/<ScpController>/5
        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    var scp = _context.Scps.SingleOrDefault(s => s.Id == id);

        //    if (scp == null)
        //    {
        //        return NoContent();
        //    }
        //    _context.Remove(scp);
        //    _context.SaveChanges();
        //    return Ok();
        //}
    }
}
