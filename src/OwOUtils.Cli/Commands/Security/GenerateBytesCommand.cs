using System.CommandLine;
using OwOUtils.Core.UseCases.Security;

namespace OwOUtils.Cli.Commands.Security;

internal sealed class GenerateBytesCommand
    : BaseCommand<GenerateBytesCommand.Request, GenerateBytesCommand>
{
    public override string Name => "bytes";
    public override string? Description => "Generate some random bytes.";

    public GenerateBytesCommand()
        : base(
            new Argument<int>(nameof(Request.Length)))
    {
    }

    public sealed class Request
        : BaseCommandRequest
    {
        public int Length { get; set; }

        public override object ToMediatorRequest() =>
            new GenerateBytes.Request
            {
                Length = Length,
            };
    }
}
