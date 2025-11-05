namespace Blazor.Models
{
    public class TodoList
    {
        public int TodoId { get; set; }
        public string Task { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime DateTime { get; set; }
    }
}
