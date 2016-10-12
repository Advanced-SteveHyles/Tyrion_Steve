using System;
using System.Collections.Generic;

namespace EventSource
{
    public class FoodOrdered
    {
        public Guid Id;
        public List<OrderedItem> Items;
    }
}