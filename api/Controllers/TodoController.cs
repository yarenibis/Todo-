using api.Data;
using api.Dtos.Todo;
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
        public TodoController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _context.Todos.ToListAsync();
            var todoDto= todos.Select(s => s.ListTodoDto());
            return Ok(todoDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await  _context.Todos.FindAsync(id);
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
           await  _context.Todos.AddAsync(todoModel);
           await  _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = todoModel.Id }, todoModel.ListTodoDto());

        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] int id, [FromBody] UpdateTodoRequest updatedModel)
        {
            var todoModel =await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
            if (todoModel == null)
            {
                return NotFound();
            }

            todoModel.Title = updatedModel.Title;
            todoModel.Description = updatedModel.Description;
            todoModel.DueDate = updatedModel.DueDate;
            todoModel.isCompleted = updatedModel.isCompleted;
            await _context.SaveChangesAsync();
            return Ok(todoModel.ListTodoDto());
        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] int id)
        {
            var todoModel =await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
            if (todoModel == null)
            {
                return NotFound();
            }
            _context.Todos.Remove(todoModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}