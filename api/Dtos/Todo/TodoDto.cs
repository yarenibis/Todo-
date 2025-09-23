using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Todo
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime DueDate{ get; set; }
        public Boolean isCompleted { get; set; }
    }
}