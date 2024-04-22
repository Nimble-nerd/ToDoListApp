using MediatR;

using ToDoService.DataAccess;
using ToDoService.Features.NewProject.Entities;

namespace ToDoService.Features.NewProject.Commands;

public class CreateTodoCommand : IRequest<IResult>
{
    public string Text { get; set; } = string.Empty;
    public DateTime Deadline { get; set; }
}
public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, IResult>
{
    ToDoDbContext _toDoDbContext;

    public CreateTodoCommandHandler(ToDoDbContext toDoDbContext)
    {
        _toDoDbContext = toDoDbContext;
    }

    public async Task<IResult> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTodoCommandValidator();
        await validator.ValidateAsync(request);

        var toDoId = Guid.NewGuid().ToString(); // Should be auto generated in a real application
        var toDoItem = new Todo() { Id = toDoId, Text = request.Text, Deadline = request.Deadline };

        await _toDoDbContext.Todos.AddAsync(toDoItem);
        await _toDoDbContext.SaveChangesAsync();
        return Results.Created($"/todo/getresourcebyid/{toDoItem.Id}", toDoItem);
    }
}