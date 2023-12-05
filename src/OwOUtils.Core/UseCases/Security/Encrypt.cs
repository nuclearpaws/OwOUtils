using System.Text;
using MediatR;
using OwOUtils.Core.Services.Security;

namespace OwOUtils.Core.UseCases.Security;

public sealed class Encrypt
    : IRequestHandler<
        Encrypt.Request,
        Encrypt.Response>
{
    private readonly IAesCryptographer _aesCryptograpgher;

    public Encrypt(
        IAesCryptographer aesCryptographer)
    {
        _aesCryptograpgher = aesCryptographer;
    }

    public Task<Response> Handle(
        Request request,
        CancellationToken cancellationToken)
    {
        var inputBytes = Encoding.UTF8.GetBytes(request.Input);
        var encrypted = _aesCryptograpgher.Encrypt(inputBytes, request.AesIv);
        var response = new Response
        {
            Encrypted = encrypted,
        };
        return Task.FromResult(response);
    }

    public sealed class Request
        : IRequest<Response>
    {
        public string Input { get; set; } = string.Empty;
        public byte[] AesIv { get; set; } = Array.Empty<byte>();
    }

    public sealed class Response
    {
        public byte[] Encrypted { get; set; } = Array.Empty<byte>();
    }
}
