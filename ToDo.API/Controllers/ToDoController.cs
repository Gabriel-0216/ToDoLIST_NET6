using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IRepository _repository;

        public ToDoController(IRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _repository.GetAll();
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<ActionResult> GetByUser(string userId)
        {
            var result = await _repository.GetByUser(userId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("ocorreu um erro");
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Post(Domain.Entities.ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(await _repository.Add(toDo))
                    {
                        return Ok("cadastrado");
                    }
                    
                }
                catch (Exception ex)
                {
                    return  BadRequest($"Ocorreu um erro :{ex.Message}");
                }
            }
            return BadRequest($"Não foi possível cadastrar");
        }

    }
}
