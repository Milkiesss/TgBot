using congrr.Data;
using congrr.UpdateIvent;
using congrr.Новая_папка;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace congrr.contr
{
    [ApiController]
    [Route("api[controller]")]
    public class Controller : ControllerBase
    {
        private readonly Data.DBContext context;
        public Controller(Data.DBContext contexT)
        {
            context = contexT;
        }
        [HttpGet]
        public IActionResult List()
        {
            var emp = context.birth.ToList();
            return Ok(emp);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var emp = context.birth.FindAsync(id);
            if (emp == null)
                return NotFound();
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult Get([FromBody] model mod)
        {
            context.birth.AddAsync(mod);
            context.SaveChanges();
            UpdateDb.OnUpdated();
            return CreatedAtAction(nameof(Get), new {id = mod.id}, mod);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = context.birth.Find(id);
            if (emp == null)
                return NotFound();
            context.birth.Remove(emp);
            context.SaveChanges();
            UpdateDb.OnUpdated();
            return NoContent();
        }
    }
}
