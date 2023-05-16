namespace API.Models.Shared
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Is_Success { get; set; } = true;
        public string Message { get; set; } = "Success";
    }
}
