namespace HackerNewsScraper.InputValidation
{
    public interface IInputValidator
    {
        InputStatus Validate(string[] args);
    }
}
