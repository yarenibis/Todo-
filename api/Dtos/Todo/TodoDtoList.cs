using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Todo
{
    public class TodoDtoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Boolean isCompleted { get; set; }
    }
}