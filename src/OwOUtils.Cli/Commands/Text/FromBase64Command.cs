using System.CommandLine;
using OwOUtils.Core.UseCases.Text;

namespace OwOUtils.Cli.Commands.Text;

internal sealed class FromBase64Command
    : BaseCommand<FromBase64Command.Request, FromBase64Command>
{
    public override string Name => "from-base64";
    public override string? Description => "Convert a base64 string to a UTF8 string.";

    public FromBase64Command()
        : base(
            new Argument<string>(nameof(Request.Base64)))
    {
    }

    public sealed class Request
        : BaseCommandRequest
    {
        public string Base64 { get; set; } = string.Empty;

        public override object ToMediatorRequest() =>
            new FromBase64.Request
            {
                Base64 = Base64,
                Encoding = FromBase64.Request.EncodingMode.Utf8,
            };
    }
}
