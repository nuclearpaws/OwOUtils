using OwOUtils.Core.UseCases.Security;

namespace OwOUtils.Cli.Commands.Security;

internal sealed class DecryptCommand
    : BaseCommand<DecryptCommand.Request, DecryptCommand>
{
    public override string Name => "decrypt";
    public override string? Description => "???";

    public DecryptCommand()
        : base()
    {
    }

    public sealed class Request
        : BaseCommandRequest
    {
        public override object ToMediatorRequest() =>
            new Decrypt.Request
            {
            };
    }
}
