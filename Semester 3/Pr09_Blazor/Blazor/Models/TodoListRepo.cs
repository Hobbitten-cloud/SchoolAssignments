namespace Blazor.Models
{
    public static class TodoListRepo
    {
        public static List<TodoList> todoLists = new List<TodoList>
        {
            new TodoList { TodoId = 1, Task = "Task 1", IsCompleted = false, DateTime = DateTime.Now },
            new TodoList { TodoId = 2, Task = "Task 2", IsCompleted = true, DateTime = DateTime.Now },
            new TodoList { TodoId = 3, Task = "Task 3", IsCompleted = false, DateTime = DateTime.Now }
        };

        public static List<TodoList> GetAllTodos()
        {
            return todoLists.OrderBy(t => t.IsCompleted).ToList();
        }

        public static void AddTodo(TodoList todo)
        {
            todoLists.Add(todo);
        }
    }
}
