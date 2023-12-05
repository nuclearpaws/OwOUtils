using OwOUtils.Cli.Commands.Text;

namespace OwOUtils.Cli.Commands;

internal sealed class TextCommand
    : BaseCommand<TextCommand>
{
    public override string Name => "text";
    public override string? Description => "Collection of Utils for Text/String manipulation.";

    public TextCommand()
        : base(
            FromBase64Command.GetCommand(),
            ToBase64Command.GetCommand())
    {
    }
}
