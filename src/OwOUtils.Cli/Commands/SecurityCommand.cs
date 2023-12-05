using OwOUtils.Cli.Commands.Security;

namespace OwOUtils.Cli.Commands;

internal sealed class SecurityCommand
    : BaseCommand<SecurityCommand>
{
    public override string Name => "security";
    public override string? Description => "Collection of Security utils.";

    public SecurityCommand()
        : base(
            DecryptCommand.GetCommand(),
            EncryptCommand.GetCommand(),
            GenerateAesIvCommand.GetCommand())
    {
    }
}
