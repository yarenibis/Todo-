using api.Data;
using api.Dtos.Todo;
using api.Interface;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace api.Controllers
{
    [Route("api/todo")]
    [ApiController]
    [Authorize]
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
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var todos = await _repository.GetAllByUserAsync(userId);
            var todoDto = todos.Select(s => s.ListTodoDto());
            return Ok(todoDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _repository.GetByIdAsync(id);

            if (result == null || result.UserId != userId)
            {
                return NotFound();
            }
            return Ok(result.ListTodoDto());
        }


        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoRequest todo)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var todoModel = todo.CreateTodoDto();
            todoModel.UserId = userId; // 🔹 Todo'yu kullanıcıya bağla

            await _repository.CreateAsync(todoModel);

            return CreatedAtAction(nameof(GetById), new { id = todoModel.Id }, todoModel.ListTodoDto());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] int id, [FromBody] UpdateTodoRequest updatedModel)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var todoModel = await _repository.GetByIdAsync(id);

            if (todoModel == null || todoModel.UserId != userId)
            {
                return NotFound();
            }

            var updatedTodo = await _repository.UpdateAsync(id, updatedModel);
            return Ok(updatedTodo.ListTodoDto());
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var todoModel = await _repository.GetByIdAsync(id);

            if (todoModel == null || todoModel.UserId != userId)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
