using System;

namespace TLAuctionv5.Mvc.Grid
{
    public interface IGridRow<out T>
    {
        String CssClasses { get; set; }
        T Model { get; }
    }
}
