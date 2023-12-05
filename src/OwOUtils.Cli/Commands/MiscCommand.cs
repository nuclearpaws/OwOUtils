using OwOUtils.Cli.Commands.Misc;

namespace OwOUtils.Cli.Commands;

internal sealed class MiscCommand
    : BaseCommand<MiscCommand>
{
    public override string Name => "misc";
    public override string? Description => "Collection of Misc utils.";

    public MiscCommand()
        : base(
            GetSystemDateTimeCommand.GetCommand())
    {
    }
}
