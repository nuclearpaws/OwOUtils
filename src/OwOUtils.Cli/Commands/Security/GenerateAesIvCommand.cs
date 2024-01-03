using OwOUtils.Core.UseCases.Security;

namespace OwOUtils.Cli.Commands.Security;

internal sealed class GenerateAesIvCommand
    : BaseCommand<GenerateAesIvCommand.Request, GenerateAesIvCommand>
{
    public override string Name => "aesiv";
    public override string? Description => "Generate a new, random and secure AesIV.";

    public GenerateAesIvCommand()
        : base()
    {
    }

    public sealed class Request
        : BaseCommandRequest
    {
        public override object ToMediatorRequest() =>
            new GenerateAesIv.Request();
    }
}
