using System;
using System.Linq;

namespace WPFDevExtremeDemo
{
    internal class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public dynamic CurrentInventory { get; set; }
        public dynamic RetailPrice { get; set; }
    }
}
