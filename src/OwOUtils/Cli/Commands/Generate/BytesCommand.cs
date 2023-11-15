
using System.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using OwOUtils.Shared.Services;

namespace OwOUtils.Cli.Commands.Generate;

internal sealed class BytesCommand
    : BaseCommand<BytesCommand.Request, byte[], BytesCommand>
{
    public override string Name => "bytes";
    public override string? Description => "Generate a random string of bytes.";

    public BytesCommand()
        : base(new Argument<int>(nameof(Request.Count), () => 16, "Number of bytes to generate."))
    {
    }

    protected override Task<byte[]> ExecuteAsync(
        Request request,
        IServiceProvider serviceProvider)
    {
        var cryptoRandomProvider = serviceProvider.GetRequiredService<ICryptoRandomProvider>();
        var bytes = cryptoRandomProvider.GetBytes(request.Count);
        return Task.FromResult(bytes);
    }

    public sealed class Request
    {
        public int Count { get; set; }
    }
}
