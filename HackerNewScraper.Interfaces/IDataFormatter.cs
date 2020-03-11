namespace HackerNewScraper.Interfaces
{
    public interface IDataFormatter<TIn, TFormatted>
    {
        TFormatted Format(TIn input);
    }
}
