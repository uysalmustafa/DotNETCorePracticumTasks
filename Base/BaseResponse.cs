using System.Text.Json.Serialization;

namespace ProductsAPI.Base
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }

        public static BaseResponse<T> Success(int statusCode, T data)
        {
            return new BaseResponse<T> { Data = data, StatusCode = statusCode };
        }

        public static BaseResponse<T> Success(int statusCode)
        {
            return new BaseResponse<T> { StatusCode = statusCode };
        }
    }
}
