namespace OpenClosedPrinciple;

/// <summary>
/// PayU ile ödeme sınıfı.
/// </summary>
public class PayUPayment : IPaymentMethod
{
    public string PayUAccountId { get; set; }

    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"PayU ile {amount} TL ödeme işlemi gerçekleştirildi.");
    }
}
