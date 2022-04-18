using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBaseService<Users> _baseService;

        public UserController(IBaseService<Users> baseService)
        {
            _baseService = baseService;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Users user)
        {
            return Execute(() => _baseService.Add<UserValidator>(user));
        }

        [HttpPut]
        public IActionResult Update([FromBody]Users user)
        {
            return Execute(() => _baseService.Update<UserValidator>(user));
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if(id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseService.Delete(id);
                return Ok("Usuário deletado");
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseService.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return Execute(() => _baseService.GetById(id));
        }
        

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
