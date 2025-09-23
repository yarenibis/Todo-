using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Todo;
using api.Models;

namespace api.Mapper
{
    public static class TodoMapper
    {
        public static TodoDto ListTodoDto(this Todo todomodel)
        {
            return new TodoDto
            {
                Id = todomodel.Id,
                Title = todomodel.Title,
                isCompleted = todomodel.isCompleted,
                DueDate = todomodel.DueDate
            };
        }

        public static Todo CreateTodoDto(this CreateTodoRequest request)
        {
            return new Todo
            {
                Title = request.Title,
                DueDate = request.DueDate,
                Description = request.Description,

            };
        }


    }
}