using MediatR;
using OwOUtils.Core.Services.Security;

namespace OwOUtils.Core.UseCases.Security;

public sealed class GenerateBytes
    : IRequestHandler<
        GenerateBytes.Request,
        GenerateBytes.Response>
{
    private readonly ICryptoRandomProvider _cryptoRandomProvider;

    public GenerateBytes(
        ICryptoRandomProvider cryptoRandomProvider)
    {
        _cryptoRandomProvider = cryptoRandomProvider;
    }

    public Task<Response> Handle(
        Request request,
        CancellationToken cancellationToken)
    {
        var bytes = _cryptoRandomProvider.GetRandomBytes(request.Length);
        var response = new Response
        {
            Bytes = bytes,
        };
        return Task.FromResult(response);
    }

    public sealed class Request
        : IRequest<Response>
    {
        public int Length { get; set; }
    }

    public sealed class Response
    {
        public byte[] Bytes { get; set; } = Array.Empty<byte>();

        public override string ToString()
        {
            var base64 = Convert.ToBase64String(Bytes);
            return base64;
        }
    }
}
