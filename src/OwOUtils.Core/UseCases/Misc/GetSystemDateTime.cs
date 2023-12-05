using MediatR;
using OwOUtils.Core.Services.Misc;

namespace OwOUtils.Core.UseCases.Misc;

public sealed class GetSystemDateTime
    : IRequestHandler<
        GetSystemDateTime.Request,
        GetSystemDateTime.Response>
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public GetSystemDateTime(
        IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public Task<Response> Handle(
        Request request,
        CancellationToken cancellationToken)
    {
        var now = _dateTimeProvider.Now;
        var response = new Response(now);
        return Task.FromResult(response);
    }

    public sealed class Request
        : IRequest<Response>
    {
    }

    public sealed class Response
    {
        public string Iso { get; set; }
        public UnixDto Unix { get; set; }

        public Response(DateTimeOffset dateTimeOffset)
        {
            Iso = dateTimeOffset.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz");
            Unix = new()
            {
                Seconds = dateTimeOffset.ToUnixTimeSeconds(),
                Ms = dateTimeOffset.ToUnixTimeMilliseconds(),
            };
        }

        public override string ToString() => this.ToJson();

        public sealed class UnixDto
        {
            public long Seconds { get; set; }
            public long Ms { get; set; }
        }
    }
}
