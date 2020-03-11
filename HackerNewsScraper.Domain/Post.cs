using System;

namespace HackerNewsScraper.Domain
{
    public class Post
    {
        public Post(string title, string uri, string author, uint points, uint comments, uint rank)
        {
            if (!string.IsNullOrEmpty(title) && title.Length <= 256)
                Title = title;
            else
                throw new ArgumentOutOfRangeException("Title must be a non-null, non-empty string not longer than 256 characters");

            if (System.Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                Uri = uri;
            else
                throw new ArgumentOutOfRangeException("Uri must be a well formed absolute URI");

            if (!string.IsNullOrEmpty(author) && author.Length <= 256)
                Author = author;
            else
                throw new ArgumentOutOfRangeException("Author of Post must be a non-null, non-empty string not longer than 256 characters");

            Points = points;
            Comments = comments;
            Rank = rank;
        }

        public string Title { get; }
        public string Uri { get; }
        public string Author{ get; }
        public uint Points { get; }
        public uint Comments { get; }
        public uint Rank { get; }

    }
}
