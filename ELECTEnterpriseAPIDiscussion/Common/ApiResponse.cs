using System.Reflection.Metadata.Ecma335;

namespace ELECTEnterpriseAPIDiscussion.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = [];
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string? TraceId { get; set; } = string.Empty;

        //Object 

        public static ApiResponse<T> SuccessResponse(T data, string message = "Request Successfull", string? traceId = null)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                TraceId = traceId
            };
        }

        public static ApiResponse<T> FailResponse(string message, List<string>? errors = null, string? traceId = null)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Data = default,
                Errors = errors ?? new List<string>(),
                TraceId = traceId
            };
        }

        public static ApiResponse<object?> SuccessResponse(string message = "Request Successfull", string? traceId = null){
            return new ApiResponse<object?>
            {
                Success = true,
                Message = message,
                Data = null,
                TraceId = traceId
            };
        }

    } 
    
}

