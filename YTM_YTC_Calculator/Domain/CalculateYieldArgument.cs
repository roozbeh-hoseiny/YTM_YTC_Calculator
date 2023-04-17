namespace YTM_YTC_Calculator.Domain;

internal readonly ref struct CalculateYieldArgument 
{ 
    /// <summary>
    /// ارزش اسمی
    /// </summary>
    public readonly double FaceValue { get; }
    /// <summary>
    /// قیمت تمام شده
    /// </summary>
    public readonly double PurchaseValue { get; }
    /// <summary>
    /// تاریخ سررسید
    /// </summary>
    public readonly string MaturityDate { get; }
    
    /// <summary>
    /// تاریخ بازخرید
    /// </summary>
    public readonly string CallDate { get; }

    private CalculateYieldArgument(double faceValue, double purchaseValue, string maturityDate, string callDate)
    {
        this.FaceValue = faceValue;
        this.PurchaseValue = purchaseValue;
        this.MaturityDate = maturityDate;
        this.CallDate = callDate;
    }

    internal static CalculateYieldArgument Create(double faceValue, double purchaseValue, string maturityDate, string callDate) => new(faceValue, purchaseValue, maturityDate, callDate);
}