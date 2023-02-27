using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pom1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pom1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PomContext _context;
        public LoginController(PomContext context) { 
            
            _context = context;
        }
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public bool Post([FromBody] int value)
        {
            var result = false;
            var user = _context.Users.Where(x => x.PhoneNumber == value).ToList();
            if (user != null && user.Count > 0)
            {
                result = false;
                return result;
            }
            return result;

        }


        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
