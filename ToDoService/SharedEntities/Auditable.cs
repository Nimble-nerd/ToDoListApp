namespace ToDoService.SharedEntities;

public class Auditable
{
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public string? LastModifiedBy { get; set; }
}
