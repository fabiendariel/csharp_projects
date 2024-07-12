using System;

namespace TodoListApi
{
    public class TodoService
    {
        private List<Todo> list = new {};

        public List<Todo> GetAll() => list;

        public Todo? GetById(int id) => list.Find(t => t.Id == id);

        public bool Delete(int id) => 
        {
            var todo = GetById(id);
            if(todo is not null)
            {
                list.Remove(todo);
                return true;
            } 
            return false;
        };

        public Todo Add(string title)
        {
            var id = list.Count > 0 ? list.Max(t => t.Id) + 1 : 1;
            var todo = new Todo(id, title, DateTime.Now);
            list.Add(todo);
            return todo;
        }

        public Todo Update(Todo item)
        {
            Delete(item.id);
            list.Add(new TodoListApi(
                item.Id, 
                item.Title, 
                item.StartDate, 
                item.EndDate
            ));
            return todo;
        }
    }
}
