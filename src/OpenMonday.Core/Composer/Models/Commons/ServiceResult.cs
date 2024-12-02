public class ServiceResult<T>
{
    public bool IsSuccess { get; private set; }
    public bool IsFailure => !IsSuccess && !IsEmpty;
    public bool IsEmpty { get; private set; }
    public T Data { get; private set; }
    public string ErrorMessage { get; private set; }

    private ServiceResult() { }

    public static ServiceResult<T> Success(T data)
    {
        return new ServiceResult<T> { IsSuccess = true, Data = data };
    }

    public static ServiceResult<T> Failure(string errorMessage)
    {
        return new ServiceResult<T> { IsSuccess = false, ErrorMessage = errorMessage };
    }

    public static ServiceResult<T> Empty()
    {
        return new ServiceResult<T> { IsSuccess = true, IsEmpty = true };
    }
}
