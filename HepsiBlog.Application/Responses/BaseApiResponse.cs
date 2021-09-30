namespace HepsiBlog.Application.Responses
{
    public class BaseApiResponse
    {
        public object Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }
    }

    public class BaseApiResponse<T>
    {
        public object Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
