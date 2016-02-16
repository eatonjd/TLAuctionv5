using System;

namespace TLAuctionv5.Mvc.Grid
{
    public class Int32Filter : NumberFilter
    {
        public override Object GetNumericValue()
        {
            Int32 number;
            if (Int32.TryParse(Value, out number))
                return number;

            return null;
        }
    }
}
