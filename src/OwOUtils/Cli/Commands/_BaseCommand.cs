using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
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

internal abstract class BaseCommand<TRequest, TResponse, TSuper>
    : BaseCommand<TSuper>
    where TRequest : notnull
    where TResponse : notnull
    where TSuper : BaseCommand<TSuper>, new()
{
    public BaseCommand(params Symbol[] children)
        : base(children)
    {
        Command.Handler = CommandHandler.Create(ActualExecuteAsync);
    }

    protected abstract Task<TResponse> ExecuteAsync(
        TRequest request,
        IServiceProvider serviceProvider);

    private async Task<int> ActualExecuteAsync(
        TRequest request,
        IHost host)
    {
        try
        {
            var response = await ExecuteAsync(
                request, host.Services);

            var json = response.ToJson();
            Console.WriteLine(json);

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"There was an unexpected exception running '{nameof(ExecuteAsync)}' of '{GetType().Name}'.");
            Console.WriteLine(ex);
            return 1;
        }
    }
}
