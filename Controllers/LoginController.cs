using Microsoft.AspNetCore.Mvc;
using POM.Models;

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
        [HttpGet("{phoneNumber}")]
        public dynamic Get(long phoneNumber)
        {
            var user = _context.Users.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefault();
            if (user == null)   //new user
            {
                //Random randomString = new Random();
                //string alphabet = "abcdefghijklmnopqrstuvwxyz";
                //int length = 4, i = 0;
                //string userReferenceCode = "";
                //while(i < length)
                //{
                //    int a = randomString.Next(26);
                //    userReferenceCode += alphabet.ElementAt(a);
                //    i++;
                //}

                User newUser = new User()
                {
                    PhoneNumber = phoneNumber,
                    CurrentLoginOtp = 123456
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                PostLoginResponse postLoginResponse = new PostLoginResponse();
                postLoginResponse.isOTPSent = true;
                postLoginResponse.isNewUser = true;
                return postLoginResponse;
            }
            else
            {
                return user;
            }
        }

        // POST api/<LoginController>
        [HttpPost]
        public dynamic Post([FromBody] long phoneNumber, string otp)
        {
            var user = _context.Users.Where(x => x.PhoneNumber == phoneNumber && x.CurrentLoginOtp == Convert.ToInt16(otp)).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            return false;
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
