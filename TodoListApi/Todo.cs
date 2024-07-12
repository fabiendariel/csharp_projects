using System;

namespace TodoListApi
{
    public class Todo
    {
        public record Todo(
            int Id, 
            string Title, 
            DateTime StartDate, 
            DateTime? EndDate = null
        );
    }
}
