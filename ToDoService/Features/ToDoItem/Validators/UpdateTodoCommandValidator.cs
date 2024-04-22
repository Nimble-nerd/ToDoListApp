using FluentValidation;

using ToDoService.Features.NewProject.Commands;

public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoCommandValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("To do text can't be empty")
                    .Must(x => x.Length < 10)
                    .WithMessage("ToDo item should be less than or equals 10 chars");

        RuleFor(x => x.Deadline).NotEmpty().NotNull().WithMessage("Deadline can not be empty");
     
        //RuleFor(x => x.Deadline)
        //    .Must(d => d >= DateTime.UtcNow)
        //    .WithMessage("ToDo item deadline should be today or in future");
    }
}