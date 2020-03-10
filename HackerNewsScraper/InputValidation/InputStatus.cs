namespace HackerNewsScraper.InputValidation
{
    public class InputStatus
    {
        public InputStatus(bool isValid)
        {
            IsValid = isValid;
        }

        public InputStatus(string errorMessage, bool isValid = false)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}
