
using System.CommandLine;

namespace OwOUtils.Cli.Commands.Generate;

internal sealed class NumberCommand
    : BaseCommand<NumberCommand.Request, int, NumberCommand>
{
    public override string Name => "number";
    public override string? Description => "Generate a random number.";

    public NumberCommand()
        : base(
            new Argument<int>(nameof(Request.Min), () => int.MinValue, "Minimum number to generate from (inclusive)."),
            new Argument<int>(nameof(Request.Max), () => int.MaxValue, "Maximum number to generate to (exclusive)."))
    {
    }

    protected override Task<int> ExecuteAsync(
        Request request,
        IServiceProvider serviceProvider)
    {
        var number = Random.Shared.Next(request.Min, request.Max);
        return Task.FromResult(number);
    }

    public sealed class Request
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
