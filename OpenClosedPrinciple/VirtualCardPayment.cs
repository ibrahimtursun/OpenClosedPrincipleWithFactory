namespace OpenClosedPrinciple;

/// <summary>
/// Sanal kart ile ödeme sınıfı.
/// </summary>
public class VirtualCardPayment : IPaymentMethod
{
    public string CardNumber { get; init; }
    public string CardHolderName { get; init; }
    public DateTime ExpiryDate { get; init; }

    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Sanal kart ile {amount} TL ödeme işlemi gerçekleştirildi.");
    }
}
