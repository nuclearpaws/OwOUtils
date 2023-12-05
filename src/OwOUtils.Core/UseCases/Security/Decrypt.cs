using System.Text;
using MediatR;
using OwOUtils.Core.Services.Security;

namespace OwOUtils.Core.UseCases.Security;

public sealed class Decrypt
    : IRequestHandler<
        Decrypt.Request,
        Decrypt.Response>
{
    private readonly IAesCryptographer _aesCryptograpgher;

    public Decrypt(
        IAesCryptographer aesCryptographer)
    {
        _aesCryptograpgher = aesCryptographer;
    }

    public Task<Response> Handle(
        Request request,
        CancellationToken cancellationToken)
    {
        var decryptedBytes = _aesCryptograpgher.Decrypt(request.Input, request.AesIv);
        var decrypted = Encoding.UTF8.GetString(decryptedBytes);
        var response = new Response
        {
            Decrypted = decrypted,
        };
        return Task.FromResult(response);
    }

    public sealed class Request
        : IRequest<Response>
    {
        public byte[] Input { get; set; } = Array.Empty<byte>();
        public byte[] AesIv { get; set; } = Array.Empty<byte>();
    }

    public sealed class Response
    {
        public string Decrypted { get; set; } = string.Empty;
    }
}
