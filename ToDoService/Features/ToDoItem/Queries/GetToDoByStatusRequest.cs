using MediatR;

using Microsoft.EntityFrameworkCore;

using ToDoService.DataAccess;

public class GetToDoByStatusRequest : IRequest<IResult>
{
    public bool Status { get; set; }
}
public class GetToDoByStatusRequestHandler : IRequestHandler<GetToDoByStatusRequest, IResult>
{
    ToDoDbContext _toDoDbContext;

    public GetToDoByStatusRequestHandler(ToDoDbContext toDoDbContext)
    {
        _toDoDbContext = toDoDbContext;
    }
    public async Task<IResult> Handle(GetToDoByStatusRequest request, CancellationToken cancellationToken)
    {
        var toDo = await _toDoDbContext
                            .Todos.Where(r => r.Status == request.Status).ToListAsync();
        if (toDo == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(toDo);
    }
}