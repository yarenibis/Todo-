using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Todo;
using api.Models;

namespace api.Interface
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo?> GetByIdAsync(int id);
        Task<Todo> CreateAsync(Todo todo);
        Task<Todo?> UpdateAsync(int id, UpdateTodoRequest request);
        Task<Todo?> DeleteAsync(int id);
    }
}