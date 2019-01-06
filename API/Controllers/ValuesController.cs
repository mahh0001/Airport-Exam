using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //private readonly DATAFACTORY _datafactory;
        //public CONTROLLERNAME(DATAFACTORY datafactory)
        //{
        //    _datafactory = datafactory;
        //}

        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //List<Model> value = _datafactory.Table.ToList();
        //return value;
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //var value = _datafactory.Table.First(x => x.Id == Id);
            //return value;
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //_datafactory.Add(value);
            //_datafactory.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            //_db.Table.Update(value);
            //_db.SaveChanges();
        }

        //[HttpPatch("{id}")] 
        //public void Patch([FromBody]JsonPatchDocument<Model> patch, int id) //patch is the model with updated values
        //{
        //    Model value = _db.Table.FirstOrDefault(x => x.Id == id);
        //    patch.ApplyTo(value, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        BadRequest(ModelState);
        //    }

        //    var model = new
        //    {
        //        original = value,
        //        patched = patch
        //    };

        //    _db.Table.Update(value);
        //    _db.SaveChanges();
        //}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //Model value = _db.Table.First(x => x.Id == id);
            //_db.Table.Remove(value);
            //_db.SaveChanges();
        }
    }
}
