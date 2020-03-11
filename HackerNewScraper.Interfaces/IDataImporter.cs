namespace HackerNewScraper.Interfaces
{
    public interface IDataImporter<TId, TData>
    {
        TData Import(TId id);
    }
}
