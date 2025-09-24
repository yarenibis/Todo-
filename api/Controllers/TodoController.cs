using api.Data;
using api.Dtos.Todo;
using api.Interface;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ITodoRepository _repository;
        public TodoController(ApplicationDBContext context, ITodoRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _repository.GetAllAsync();
            var todoDto = todos.Select(s => s.ListTodoDto());
            return Ok(todoDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ListTodoDto());
        }


        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoRequest todo)
        {
            var todoModel = todo.CreateTodoDto();
            await _repository.CreateAsync(todoModel);
            return CreatedAtAction(nameof(GetById), new { id = todoModel.Id }, todoModel.ListTodoDto());

        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] int id, [FromBody] UpdateTodoRequest updatedModel)
        {
            var todoModel = await _repository.UpdateAsync(id, updatedModel);
            if (todoModel == null)
            {
                return NotFound();
            }


            return Ok(todoModel.ListTodoDto());
        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] int id)
        {
            var todoModel = await _repository.DeleteAsync(id);
            if (todoModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}