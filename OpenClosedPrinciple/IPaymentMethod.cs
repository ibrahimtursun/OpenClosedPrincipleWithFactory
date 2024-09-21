namespace OpenClosedPrinciple;

/// <summary>
/// Ödeme sınıflarının ortak interface'i.
/// </summary>
public interface IPaymentMethod
{
    void ProcessPayment(decimal amount);
}
