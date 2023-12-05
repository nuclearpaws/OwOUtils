using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OwOUtils.Cli.Commands;

internal abstract class BaseCommand<TSuper>
    where TSuper : BaseCommand<TSuper>, new()
{
    public abstract string Name { get; }
    public abstract string? Description { get; }

    protected Command Command { get; private set; }

    public BaseCommand(params Symbol[] children)
    {
        Command = new Command(Name, Description);

        foreach (var option in children.Where(c => c is Option).Cast<Option>().ToList())
            Command.AddOption(option);

        foreach (var argument in children.Where(c => c is Argument).Cast<Argument>().ToList())
            Command.AddArgument(argument);

        foreach (var command in children.Where(c => c is Command).Cast<Command>().ToList())
            Command.AddCommand(command);
    }

    public static Command GetCommand() => new TSuper().Command;
}

internal abstract class BaseCommand<TCommandRequest, TSuper>
    : BaseCommand<TSuper>
    where TCommandRequest : notnull, BaseCommandRequest
    where TSuper : BaseCommand<TSuper>, new()
{
    public BaseCommand(params Symbol[] children)
        : base(children)
    {
        Command.Handler = CommandHandler.Create(ExecuteAsync);
    }

    private async Task<int> ExecuteAsync(
        TCommandRequest commandRequest,
        IHost host)
    {
        try
        {
            var mediator = host.Services.GetRequiredService<IMediator>();
            var mediatorRequest = commandRequest.ToMediatorRequest();
            var mediatorResponse = await mediator.Send(mediatorRequest);

            Console.WriteLine(mediatorResponse?.ToString() ?? "No response.");

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"There was an unexpected exception running '{nameof(ExecuteAsync)}' of '{GetType().Name}'.");
            Console.WriteLine(commandRequest.Verbose
                ? ex
                : $"{ex.GetType()}: {ex.Message}");

            return 1;
        }
    }
}
