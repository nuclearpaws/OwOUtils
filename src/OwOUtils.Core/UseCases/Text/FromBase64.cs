using MediatR;

namespace OwOUtils.Core.UseCases.Text;

public sealed class FromBase64
    : IRequestHandler<
        FromBase64.Request,
        FromBase64.Response>
{
    public Task<Response> Handle(
        Request request,
        CancellationToken cancellationToken)
    {
        var bytes = Convert.FromBase64String(request.Base64);
        var text = request.Encoding switch
        {
            Request.EncodingMode.Ascii => System.Text.Encoding.ASCII.GetString(bytes),
#pragma warning disable SYSLIB0001
            Request.EncodingMode.Utf7 => System.Text.Encoding.UTF7.GetString(bytes),
#pragma warning restore SYSLIB0001
            Request.EncodingMode.Utf8 => System.Text.Encoding.UTF8.GetString(bytes),
            Request.EncodingMode.Utf32 => System.Text.Encoding.UTF32.GetString(bytes),
            _ => throw new ArgumentOutOfRangeException(nameof(request)),
        };
        var response = new Response
        {
            Text = text,
        };
        return Task.FromResult(response);
    }

    public sealed class Request
        : IRequest<Response>
    {
        public string Base64 { get; set; } = string.Empty;
        public EncodingMode Encoding { get; set; } = EncodingMode.Utf8;

        public enum EncodingMode
        {
            Ascii = 0,
            Utf7 = 1,
            Utf8 = 2,
            Utf32 = 3,
        }
    }

    public sealed class Response
    {
        public string Text { get; set; } = string.Empty;

        public override string ToString()
        {
            return Text;
        }
    }
}
