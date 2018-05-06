using System;

namespace Eyrebot.Models
{
    public class GdaxCurrencyDetailsModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Symbol { get; set; }
        public Int32 TradeId { get; set; }
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal Volume { get; set; }
        public DateTime Time { get; set; }
    }
}