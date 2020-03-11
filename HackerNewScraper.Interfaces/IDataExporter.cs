namespace HackerNewScraper.Interfaces
{
    public interface IDataExporter<TData>
    {
        void Export(TData data);
    }
}
