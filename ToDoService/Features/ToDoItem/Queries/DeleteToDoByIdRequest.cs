using MediatR;
using ToDoService.DataAccess;

public class DeleteToDoByIdRequest : IRequest<IResult>
{
    public string Id { get; set; }
}

public class DeleteToDoByIdRequestHandler : IRequestHandler<DeleteToDoByIdRequest, IResult>
{
    ToDoDbContext _toDoDbContext;

    public DeleteToDoByIdRequestHandler(ToDoDbContext toDoDbContext)
    {
        _toDoDbContext = toDoDbContext;
    }
    public async Task<IResult> Handle(DeleteToDoByIdRequest request, CancellationToken cancellationToken)
    {
        var toDoItem = await _toDoDbContext.Todos.FindAsync(request.Id);

        if (toDoItem == null)
        {
            return Results.NotFound();
        }
        _toDoDbContext.Todos.Remove(toDoItem);
        await _toDoDbContext.SaveChangesAsync(cancellationToken);

        return Results.NoContent();
    }
}
