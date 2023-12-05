using MediatR;
using OwOUtils.Core.Services.Security;

namespace OwOUtils.Core.UseCases.Security;

public sealed class GenerateAesIv
    : IRequestHandler<
        GenerateAesIv.Request,
        GenerateAesIv.Response>
{
    private readonly ICryptoRandomProvider _cryptoRandomProvider;

    public GenerateAesIv(
        ICryptoRandomProvider cryptoRandomProvider)
    {
        _cryptoRandomProvider = cryptoRandomProvider;
    }

    public Task<Response> Handle(
        Request request,
        CancellationToken cancellationToken)
    {
        var aesIv = _cryptoRandomProvider.GetRandomBytes(16);
        var response = new Response
        {
            AesIv = aesIv,
        };
        return Task.FromResult(response);
    }

    public sealed class Request
        : IRequest<Response>
    {
    }

    public sealed class Response
    {
        public byte[] AesIv { get; set; } = Array.Empty<byte>();

        public override string ToString()
        {
            var base64 = Convert.ToBase64String(AesIv);
            return base64;
        }
    }
}
