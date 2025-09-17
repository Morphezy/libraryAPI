using System.Text.Json;

namespace Domain.Exceptions;

public class GlobalExceptionDto
{
    public string Message { get;  set; } = "Something went wrong";

    public int StatusCode { get; set; } = 400;
    
    public string HelpLink { get;  set; } = "https://datatracker.ietf.org/doc/html/rfc9110#section-15.5.1";

    public string Source { get; set; } = string.Empty;
    
    public string StackTrace { get; set; } =  string.Empty;
    

    public override string ToString()
    {
       return JsonSerializer.Serialize(this);
    }
    
    
    
    
}