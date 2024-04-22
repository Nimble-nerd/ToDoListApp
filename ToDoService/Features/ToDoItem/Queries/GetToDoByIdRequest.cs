using MediatR;

using ToDoService.DataAccess;

public class GetToDoByIdRequest : IRequest<IResult>
{
    public string Id { get; set; }
}
public class GetToDoByIdRequstHandler : IRequestHandler<GetToDoByIdRequest, IResult>
{
    ToDoDbContext _toDoDbContext;

    public GetToDoByIdRequstHandler(ToDoDbContext toDoDbContext)
    {
        _toDoDbContext = toDoDbContext;
    }
    public async Task<IResult> Handle(GetToDoByIdRequest request, CancellationToken cancellationToken)
    {
        var toDo = await _toDoDbContext.Todos.FindAsync(request.Id);

        if (toDo == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(toDo);
    }
}
