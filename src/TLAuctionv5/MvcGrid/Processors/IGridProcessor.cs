using System.Linq;

namespace TLAuctionv5.Mvc.Grid
{
    public interface IGridProcessor<T>
    {
        GridProcessorType ProcessorType { get; set; }

        IQueryable<T> Process(IQueryable<T> items);
    }
}
