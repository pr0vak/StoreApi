using System.Net;

namespace Api.Models;

public class ServerResponse
{
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public List<string> ErrorMessages { get; set; }
    public object Result { get; set; }

    public ServerResponse()
    {
        this.IsSuccess = true;
        this.ErrorMessages = new();
    }
}