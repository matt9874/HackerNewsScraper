namespace HackerNewsScraper.InputValidation
{
    public class InputValidator: IInputValidator
    {
        private const string _genericErrorMessage =
            "HackerNewsScraper must be executed with --posts as the first argument followed by an integer argument";

        public InputStatus Validate(string[] args)
        {
            if (args.Length < 2)
                return new InputStatus(_genericErrorMessage);

            if (args[0] == "--posts" && int.TryParse(args[1], out int numPosts))
            {
                if(numPosts > 0 && numPosts <= 100)
                    return new InputStatus(true);
                return new InputStatus("The number of posts requested must be a positive integer less than or equal to 100");
            }
            return new InputStatus(_genericErrorMessage);
        }
    }
}
