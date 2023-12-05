using OwOUtils.Core.UseCases.Misc;

namespace OwOUtils.Cli.Commands.Misc;

internal sealed class GetSystemDateTimeCommand
    : BaseCommand<GetSystemDateTimeCommand.Request, GetSystemDateTimeCommand>
{
    public override string Name => "datetimenow";
    public override string? Description => "Get the current date time offset ISO string based on system clock.";

    public GetSystemDateTimeCommand()
        : base()
    {
    }

    public sealed class Request
        : BaseCommandRequest
    {
        public override object ToMediatorRequest() =>
            new GetSystemDateTime.Request();
    }
}
