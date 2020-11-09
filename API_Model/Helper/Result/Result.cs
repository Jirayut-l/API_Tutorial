namespace API_Model
{
    public class Result
    {
        public bool Success { get; set; }
        public string DisplayMessage { get; set; }
        public string InternalMessage { get; set; }
    }

    public class Result<T> : Result
    {
        public T Value { get; set; }
    }
}