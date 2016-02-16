using System;

namespace TLAuctionv5.Mvc.Grid
{
    public class Int64Filter : NumberFilter
    {
        public override Object GetNumericValue()
        {
            Int64 number;
            if (Int64.TryParse(Value, out number))
                return number;

            return null;
        }
    }
}
