
public class ServiceResult
{
    public ServiceStatus Status { get; set; }
    public string ErrorMessage { get; set; }
}
public class ServiceResult<T> : ServiceResult
{
    public T Model { get; set; }
}

public enum ServiceStatus
{
    Ok,
    Error
}

public class ServiceResultOk<T> : ServiceResult<T>
{
    public ServiceResultOk(T model)
    {
        base.Status = ServiceStatus.Ok;
        base.Model = model;
    }
}


public class ServiceResultError<T> : ServiceResult<T>
{
    public ServiceResultError(string ErrorMessage)
    {
        base.Status = ServiceStatus.Error;
        base.ErrorMessage = ErrorMessage;
    }
}

public class ServiceResultError : ServiceResult
{
    public ServiceResultError(string ErrorMessage)
    {
        base.Status = ServiceStatus.Error;
        base.ErrorMessage = ErrorMessage;

    }
}