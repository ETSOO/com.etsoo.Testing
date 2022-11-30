namespace com.etsoo.Testing.Mocks
{
    /// <summary>
    /// Request handler delegate
    /// 请求处理程序委托
    /// </summary>
    /// <param name="request">Request message</param>
    /// <returns>Response message</returns>
    public delegate HttpResponseMessage RequestHandler(HttpRequestMessage request);

    /// <summary>
    /// Mock HttpMessageHandler
    /// 模拟 HttpMessageHandler
    /// https://medium.com/younited-tech-blog/easy-httpclient-mocking-3395d0e5c4fa
    /// </summary>
    public class HttpMessageHandlerMock : HttpMessageHandler
    {
        private readonly RequestHandler _handler;

        public HttpMessageHandlerMock(RequestHandler handler)
        {
            _handler = handler;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(_handler(request));
        }
    }
}
