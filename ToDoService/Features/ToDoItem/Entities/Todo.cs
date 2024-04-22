namespace ToDoService.Features.NewProject.Entities;

public class Todo
{
    public string Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime Deadline { get; set; }
    public bool Status { get; set; } = false;
}

