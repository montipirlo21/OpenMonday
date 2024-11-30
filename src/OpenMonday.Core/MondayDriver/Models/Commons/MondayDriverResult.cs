

    public class MondayDriverResult<T>
    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess && !IsEmpty;
        public bool IsEmpty { get; private set; }
        public T? Data { get; private set; }
        public string? ErrorMessage { get; private set; }

        public static MondayDriverResult<T> Success(T data)
        {
            return new MondayDriverResult<T> { IsSuccess = true, Data = data };
        }

        public static MondayDriverResult<T> Failure(string errorMessage)
        {
            return new MondayDriverResult<T> { IsSuccess = false, ErrorMessage = errorMessage };
        }

        public static MondayDriverResult<T> Empty()
        {
            return new MondayDriverResult<T> { IsSuccess = true, IsEmpty = true };
        }
    }
