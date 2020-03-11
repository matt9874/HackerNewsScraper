namespace HackerNewScraper.Interfaces
{
    public interface IDataParser<TData, TParsed>
    {
        TParsed Parse(TData data);
    }
}
