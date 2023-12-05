using MediatR;

namespace OwOUtils.Core.UseCases.Text;

public sealed class ToBase64
    : IRequestHandler<
        ToBase64.Request,
        ToBase64.Response>
{
    public Task<Response> Handle(
        Request request,
        CancellationToken cancellationToken)
    {
        var bytes = request.Encoding switch
        {
            Request.EncodingMode.ASCII => System.Text.Encoding.ASCII.GetBytes(request.Text),
#pragma warning disable SYSLIB0001
            Request.EncodingMode.UTF7 => System.Text.Encoding.UTF7.GetBytes(request.Text),
#pragma warning restore SYSLIB0001
            Request.EncodingMode.UTF8 => System.Text.Encoding.UTF8.GetBytes(request.Text),
            Request.EncodingMode.UTF32 => System.Text.Encoding.UTF32.GetBytes(request.Text),
            _ => throw new ArgumentOutOfRangeException(nameof(request)),
        };
        var base64 = Convert.ToBase64String(bytes);
        var response = new Response
        {
            Base64 = base64,
        };
        return Task.FromResult(response);
    }

    public sealed class Request
        : IRequest<Response>
    {
        public string Text { get; set; } = string.Empty;
        public EncodingMode Encoding { get; set; } = EncodingMode.UTF8;

        public enum EncodingMode
        {
            ASCII = 0,
            UTF7 = 1,
            UTF8 = 2,
            UTF32 = 3,
        }
    }

    public sealed class Response
    {
        public string Base64 { get; set; } = string.Empty;

        public override string ToString()
        {
            return Base64;
        }
    }
}
