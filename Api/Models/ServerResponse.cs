using System.Net;

namespace Api.Models;

public class ServerResponse
{
    public bool IsSuccess { get; set; } = true;
    public HttpStatusCode StatusCode { get; set; }
    public List<string>? ErrorMessages { get; set; } = [];
    public object? Result { get; set; }
}
