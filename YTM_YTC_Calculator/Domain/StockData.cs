namespace YTM_YTC_Calculator.Domain
{
    internal record StockData
    {
        /// <summary>
        /// نماد
        /// </summary>
        public required string Symbol { get; set; }
        
        /// <summary>
        /// قیمت آخرین معامله | فرض شده است که قیمت است
        /// </summary>
        public double LastPriceTransaction { get; set; }
        
        /// <summary>
        /// قیمت پایانی | فرض شده است که قیمت اسمی است
        /// </summary>
        public double LastPrice { get; set; }
    }
}
