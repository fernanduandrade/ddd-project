using Domain.Entities;
using Domain.Interfaces;
using Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IBaseService<User> _baseService;

        public UserController(IBaseService<User> baseService)
        {
            _baseService = baseService;
        }

        [HttpPost]
        public IActionResult Create([FromBody]User user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseService.Add<UserValidator>(user));
        }

        [HttpPut]
        public IActionResult Update([FromBody]User user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseService.Update<UserValidator>(user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseService.GetAll());
        }

        [HttpGet("{id}")]
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
