using api.Data;
using api.Dtos.Todo;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var todos = _context.Todos.ToList().Select(s => s.ListTodoDto());
            return Ok(todos);
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _context.Todos.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result.ListTodoDto());
        }


        [HttpPost]
        public IActionResult CreateTodo([FromBody] CreateTodoRequest todo)
        {
            var todoModel = todo.CreateTodoDto();
            _context.Todos.Add(todoModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = todoModel.Id }, todoModel.ListTodoDto());

        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTodo([FromRoute] int id, [FromBody] UpdateTodoRequest updatedModel)
        {
            var todoModel = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todoModel == null)
            {
                return NotFound();
            }

            todoModel.Title = updatedModel.Title;
            todoModel.Description = updatedModel.Description;
            todoModel.DueDate = updatedModel.DueDate;
            todoModel.isCompleted = updatedModel.isCompleted;
            _context.SaveChanges();
            return Ok(todoModel.ListTodoDto());
        }



        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTodo([FromRoute] int id)
        {
            var todoModel = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todoModel == null)
            {
                return NotFound();
            }
            _context.Todos.Remove(todoModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}