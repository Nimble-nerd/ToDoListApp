using MediatR;

using Microsoft.EntityFrameworkCore;

using ToDoService.DataAccess;

public class GetAllToDoRequest : IRequest<IResult> { }

public class GetToDoRequstHandler : IRequestHandler<GetAllToDoRequest, IResult>
{
    ToDoDbContext _toDoDbContext;
    public GetToDoRequstHandler(ToDoDbContext toDoDbContext)
    {
        _toDoDbContext = toDoDbContext;
    }
    public async Task<IResult> Handle(GetAllToDoRequest request, CancellationToken cancellationToken)
    {
        var todoItems = await _toDoDbContext.Todos.ToListAsync();
        return Results.Ok(todoItems);
    }
}