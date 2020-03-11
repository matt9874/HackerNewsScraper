namespace HackerNewsScraper.InputHandling
{
    public class Input
    {
        public Input(uint numPosts)
        {
            IsValid = true;
            NumPosts = numPosts;
        }

        public Input(string errorMessage)
        {
            IsValid = false;
            ErrorMessage = errorMessage;
        }

        public bool IsValid { get;}
        public string ErrorMessage { get;}
        public uint NumPosts { get;}
    }
}
