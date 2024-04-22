namespace ToDoService.DataAccess;

using Microsoft.EntityFrameworkCore;

using ToDoService.Features.NewProject.Entities;

public class ToDoDbContext : DbContext
{
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options) { }
    public DbSet<Todo> Todos { get; set; }
}