using System;
using System.Collections.Generic;

namespace EventSource
{
    public class PlaceOrder
    {
        public Guid Id;
        public List<OrderedItem> Items;
    }
}