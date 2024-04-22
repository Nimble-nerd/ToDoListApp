//using Asp.Versioning;
//using Asp.Versioning.Builder;
//using Carter;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;
//using ToDoService.Features.NewProject.Commands;
//using ToDoService.Features.NewProject.Entities;

//namespace ToDoService.Features.NewProject;

//public class CarterToDoModule : CarterModule
//{
//    public CarterToDoModule()
//        : base("") { }
//    public override void AddRoutes(IEndpointRouteBuilder app)
//    {
//        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
//            .HasApiVersion(new ApiVersion(1))
//            .ReportApiVersions()
//            .Build();

//        RouteGroupBuilder group = app
//            .MapGroup("api/v{version:apiVersion}")
//            .WithApiVersionSet(apiVersionSet);

//        group.MapPost("/todo", async ([FromBody] CreateTodoCommand todoCommand, IMediator mediator) =>
//            {
//                var result = await mediator.Send(todoCommand);
//                return result;
//            })
//            .Accepts<Todo>("application/json")
//            .Produces(201)
//            .Produces(StatusCodes.Status400BadRequest)
//            .WithTags("CreateToDo")
//            .WithOpenApi(operation => new(operation)
//            {
//                Summary = "Create a todo item",
//                Description = "Create a todo item"
//            })
//            .AddFluentValidationAutoValidation();

//        group.MapPut("/todo", async ([FromBody] UpdateTodoCommand todoCommand, IMediator mediator) =>
//        {
//            var result = await mediator.Send(todoCommand);
//            return result;
//        })
//          .Accepts<Todo>("application/json")
//          .Produces(201)
//          .Produces(StatusCodes.Status400BadRequest)
//          .WithTags("CreateToDo")
//          .WithOpenApi(operation => new(operation)
//          {
//              Summary = "Create a todo item",
//              Description = "Create a todo item"
//          })
//          .AddFluentValidationAutoValidation();

//        group.MapGet("/todos/{id}",
//                async (IMediator mediator, [AsParameters] GetToDoByIdRequest request)
//                    => await mediator.Send(request)
//            )
//            .WithName("GetToDoByIdRequest")
//            .WithTags("GetToDoByIdRequest")
//            .WithOpenApi(operation => new(operation)
//            {
//                Summary = "Get a todo item by id",
//                Description = "Get a todo item by id"
//            });

//        group.MapGet("/todos", async (IMediator mediator, [AsParameters] GetAllToDoRequest request)
//                  => await mediator.Send(request)
//          )
//          .WithName("GetAllToDoRequst")
//          .WithTags("GetAllToDoRequst")
//          .WithOpenApi(operation => new(operation)
//          {
//              Summary = "Get all todo items",
//              Description = "Get all todo items"
//          });
//        group.MapDelete("/todo/{id}",
//              async (IMediator mediator, [AsParameters] DeleteToDoByIdRequest request)
//                  => await mediator.Send(request)
//          )
//          .WithName("DeleteToDoByIdRequest")
//          .WithTags("DeleteToDoByIdRequest")
//          .WithOpenApi(operation => new(operation)
//          {
//              Summary = "Delete a todo item by id",
//              Description = "Deletea todo item by id"
//          });
//    }
//}