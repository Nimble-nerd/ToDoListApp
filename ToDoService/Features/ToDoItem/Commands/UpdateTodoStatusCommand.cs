using MediatR;

using Microsoft.EntityFrameworkCore;

using ToDoService.DataAccess;

namespace ToDoService.Features.NewProject.Commands;

public class UpdateTodoStatusCommand : IRequest<IResult>
{
    public string Id { get; set; } 
    public bool Status { get; set; }
}

public class UpdateTodoStatusCommandHandler : IRequestHandler<UpdateTodoStatusCommand, IResult>
{
    ToDoDbContext _toDoDbContext;

    public UpdateTodoStatusCommandHandler(ToDoDbContext toDoDbContext)
    {
        _toDoDbContext = toDoDbContext;
    }

    public async Task<IResult> Handle(UpdateTodoStatusCommand request, CancellationToken cancellationToken)
    {
        var toDoItem = await _toDoDbContext.Todos.FindAsync(request.Id);

        if (toDoItem == null)
        {
            return Results.NotFound();
        }

        toDoItem.Status = request.Status;
        _toDoDbContext.Todos.Update(toDoItem);
        await _toDoDbContext.SaveChangesAsync();

        return Results.Ok(toDoItem);
    }
}