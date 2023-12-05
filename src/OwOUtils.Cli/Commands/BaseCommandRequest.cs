namespace OwOUtils.Cli.Commands;

internal abstract class BaseCommandRequest
{
    public bool Verbose { get; set; }

    public abstract object ToMediatorRequest();
}
