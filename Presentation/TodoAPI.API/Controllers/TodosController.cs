using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoAPI.Application.Abstactions;
using TodoAPI.Application.Repositories;
using TodoAPI.Application.RequestParameters;
using TodoAPI.Application.ViewModels.Todos;
using TodoAPI.Domain.Entities;

namespace TodoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoWriteRepository _todoWriteRepository;
        private readonly ITodoReadRepository _todoReadRepository;

        public TodosController(ITodoWriteRepository todoWriteRepository, ITodoReadRepository todoReadRepository)
        {
            _todoWriteRepository = todoWriteRepository;
            _todoReadRepository = todoReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            var totalCount = _todoReadRepository.GetAll(false).Count();
            var todos = _todoReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Description,
                p.Users,
                p.Departments,
                p.EndTime,
                p.Created,
                p.Updated,
            }).ToList();

            //Select(p => new
            //{
            //    p.Id,
            //    p.Name,
            //    p.Description,
            //    p.Users,
            //    p.Departments,
            //    p.EndTime,
            //    p.Created,
            //    p.Updated,
            //}).Skip(pagination.Page * pagination.Size).Take(pagination.Size);

            return Ok(new { totalCount, todos });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_todoReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Todo model)
        {
            await _todoWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Description = model.Description,
                Users = model.Users,
                Departments = model.Departments,
                EndTime = model.EndTime
            });

            await _todoWriteRepository.SaveAsync();

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Todo model)
        {
            Todo todo = await _todoReadRepository.GetByIdAsync(model.Id);
            todo.Name = model.Name;
            todo.Description = model.Description;
            //todo.Users = model.Users;
            //todo.Departments = model.Departments;
            todo.EndTime = model.EndTime;
            await _todoWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _todoWriteRepository.RemoveAsync(id);
            await _todoWriteRepository.SaveAsync();
            return Ok();
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    Todo todo = await _todoReadRepository.GetByIdAsync(id);
        //    return Ok(todo);
        //}
    }
}
