﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eyrebot.Models
{
    public class BinanceCurrencyDetailsModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Symbol { get; set; }
        public decimal PriceChange { get; set; }
        public decimal PriceChangePercent { get; set; }
        public decimal WeightedAvgPrice { get; set; }
        public decimal PrevClosePrice { get; set; }
        public decimal LastPrice { get; set; }
        public decimal LastQty { get; set; }
        public decimal BidPrice { get; set; }
        public decimal BidQty { get; set; }
        public decimal AskPrice { get; set; }
        public decimal AskQty { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal Volume { get; set; }
        public decimal QuoteVolume { get; set; }
        public Int64 OpenTime { get; set; }
        public Int64 CloseTime { get; set; }
        public Int64 FirstId { get; set; }
        public Int64 LastId { get; set; }
        public Int64 Count { get; set; }


        public decimal RoundedPriceChangePercent => Math.Round(PriceChangePercent, 2);
        public decimal RoundedLastPrice => Math.Round(LastPrice, 2);
        public decimal RoundedWeightedAvgPrice => Math.Round(WeightedAvgPrice, 2);
        public decimal RoundedPrevClosePrice => Math.Round(PrevClosePrice, 2);
        public decimal RoundedHighPrice => Math.Round(HighPrice, 2);
        public decimal RoundedLowPrice => Math.Round(LowPrice, 2);
        public decimal RoundedVolume => Math.Round(Volume, 2);
    }
}