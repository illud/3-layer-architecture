using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using _3LayerArchitecture.Dto;
using Business_Logic_Layer.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _3LayerArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly Business_Logic_Layer.UsersBLL _BLL;

        public UsersController()
        {
            _BLL = new Business_Logic_Layer.UsersBLL();
        }

        // GET: api/<UsersController>
        [HttpGet]
        public Task<List<UserModel>> Get()
        {
            return _BLL.GetUsers();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost("create"), AllowAnonymous]
        public Task<string> Post([FromBody] UserDto user)
        {
            return _BLL.CreateUser(new UserModel
            {
                Id = user.Id,
                Age = user.Age,
                Name = user.Name,
                Password = user.Password,
                UserName = user.UserName
            });
        }

        [HttpPost("login"), AllowAnonymous]
        public Task<string> PostLogin(UserLoginDto user)
        {
            return _BLL.Login(user.UserName, user.Password);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
