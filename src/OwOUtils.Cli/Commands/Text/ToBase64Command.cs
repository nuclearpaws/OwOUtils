using System.CommandLine;
using OwOUtils.Core.UseCases.Text;

namespace OwOUtils.Cli.Commands.Text;

internal sealed class ToBase64Command
    : BaseCommand<ToBase64Command.Request, ToBase64Command>
{
    public override string Name => "to-base64";
    public override string? Description => "Convert UTF8 string to a base64 string.";

    public ToBase64Command()
        : base(
            new Argument<string>(nameof(Request.Text)))
    {
    }

    public sealed class Request
        : BaseCommandRequest
    {
        public string Text { get; set; } = string.Empty;

        public override object ToMediatorRequest() =>
            new ToBase64.Request
            {
                Text = Text,
                Encoding = ToBase64.Request.EncodingMode.UTF8,
            };
    }
}
