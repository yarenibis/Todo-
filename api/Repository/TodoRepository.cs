using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Todo;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDBContext _context;
        public TodoRepository(ApplicationDBContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Todo> CreateAsync(Todo todoModel)
        {
            await _context.Todos.AddAsync(todoModel);
            await _context.SaveChangesAsync();
            return todoModel;
        }

        public async Task<Todo?> DeleteAsync(int id)
        {
            var todo_model = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todo_model == null)
            {
                return null;
            }
            _context.Todos.Remove(todo_model);
            await _context.SaveChangesAsync();
            return todo_model;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();
        }
         public async Task<List<Todo>> GetAllByUserAsync(string userId)
        {
            // Kullanıcıya göre filtre
            return await _context.Todos
                                 .Where(t => t.UserId == userId)
                                 .OrderByDescending(t => t.CreateAt)
                                 .ToListAsync();
        }



        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<Todo?> UpdateAsync(int id, UpdateTodoRequest request)
        {
            var todoModel = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (todoModel == null)
            {
                return null;
            }

            todoModel.Title = request.Title;
            todoModel.Description = request.Description;
            todoModel.DueDate = request.DueDate;
            todoModel.isCompleted = request.isCompleted;

            await _context.SaveChangesAsync();
            return todoModel;
        }
    }
}