using System;

namespace API_Model
{
    public class ResultMessage
    {
        public static Result ExceptionError(Exception ex)
        {
            var result = new Result
            {
                Success = false,
                InternalMessage = ex?.ToString(),

            };
            return result;
        }

        public static Result Success(string displayMessage)
        {
            var result = new Result
            {
                Success = true,
                DisplayMessage = displayMessage
            };
            return result;
        }

        public static Result Error(string displayMessage)
        {
            var result = new Result
            {
                Success = false,
                DisplayMessage = displayMessage
            };
            return result;
        }
    }

    public class ResultMessage<T>
    {
        public static Result<T> Error(string displayMessage)
        {
            var result = new Result<T>
            {
                Success = false,
                DisplayMessage = displayMessage
            };
            return result;
        }

        public static Result<T> ExceptionError(Exception ex)
        {
            var result = new Result<T>
            {
                Success = false,
                InternalMessage = ex?.ToString()
            };
            return result;
        }

        public static Result<T> Success(T value)
        {
            var result = new Result<T>
            {
                Success = true,
                Value = value
            };
            return result;
        }

    }
}