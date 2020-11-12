namespace TodoApp.Models
{
    public class Todo
    {
        public long Id { get; set; }
        public string Title{ get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
    }
}