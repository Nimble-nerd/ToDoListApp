using MediatR;

using ToDoService.DataAccess;

namespace ToDoService.Features.NewProject.Commands;

public class UpdateTodoCommand : IRequest<IResult>
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Text { get; set; } = string.Empty;
    public DateTime Deadline { get; set; }
    public bool Status { get; set; }
}

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, IResult>
{
    ToDoDbContext _toDoDbContext;

    public UpdateTodoCommandHandler(ToDoDbContext toDoDbContext)
    {
        _toDoDbContext = toDoDbContext;
    }

    public async Task<IResult> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateTodoCommandValidator();
        await validator.ValidateAsync(request);

        var toDoItem = await _toDoDbContext.Todos.FindAsync(request.Id);

        if (toDoItem == null)
        {
            return Results.NotFound();
        }

        toDoItem.Text = request.Text;
        toDoItem.Deadline = request.Deadline;

        _toDoDbContext.Todos.Update(toDoItem);
        await _toDoDbContext.SaveChangesAsync();

        return Results.Ok(toDoItem);
    }
}
