namespace Domain.Exceptions;

public class GlobalException
{
    public string Message { get;  private set; }
    public string Type { get; private set; }
    public string Code { get; private set; }
    
    
    public GlobalException(string message, string type, string code)
    {
        Message = message;
        Type = type;
        Code = code;
    }
    
    
    
    
}