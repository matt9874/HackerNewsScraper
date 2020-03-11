namespace HackerNewsScraper.InputHandling
{
    public class InputParser: IInputParser
    {
        private const string _genericErrorMessage =
            "HackerNewsScraper must be executed with --posts as the first argument followed by an integer argument";

        public Input Parse(string[] args)
        {
            if (args.Length < 2)
                return new Input(_genericErrorMessage);

            if (args[0] == "--posts" && uint.TryParse(args[1], out uint numPosts))
            {
                if(numPosts > 0 && numPosts <= 100)
                    return new Input(numPosts);
                return new Input("The number of posts requested must be a positive integer less than or equal to 100");
            }
            return new Input(_genericErrorMessage);
        }
    }
}
