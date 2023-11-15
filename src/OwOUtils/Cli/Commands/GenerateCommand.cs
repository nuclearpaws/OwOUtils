using OwOUtils.Cli.Commands.Generate;

namespace OwOUtils.Cli.Commands;

internal sealed class GenerateCommand
    : BaseCommand<GenerateCommand>
{
    public override string Name => "generate";
    public override string? Description => "Collection of Utils for Generating Data.";

    public GenerateCommand()
        : base(
            NumberCommand.GetCommand(),
            BytesCommand.GetCommand())
    {
    }
}
