namespace ExceptionSystem.ToolingExceptions;

public class UnwrapException : Exception
{
    public UnwrapException(string message)  : base(message)
    {
        // Log exception
    }
}
