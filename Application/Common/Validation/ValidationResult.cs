namespace Application.Common.Validation
{
    public readonly struct ValidationResult
    {
        public bool Valid { get; }
        public string Message { get; }

        private ValidationResult(bool valid, string message)
        {
            Valid = valid;
            Message = message;
        }

        private const string DefaultErrorMessage = "The request is invalid!";
        
        public static ValidationResult Failure(string message = DefaultErrorMessage) => new ValidationResult(false, message);
        public static ValidationResult Success() => new ValidationResult(true, string.Empty);
    }
}