using Microsoft.Extensions.Configuration;

namespace OpenClosedPrinciple;

/// <summary>
/// Appsetting'e göre hangi ödeme yönteminin kullanılacağını dönen factory sınıfı.
/// </summary>
public class PaymentMethodFactory
{
    private readonly IConfiguration _configuration;

    public PaymentMethodFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // Ödeme yöntemini dinamik olarak dönen factory metot.
    public IPaymentMethod CreatePaymentMethod()
    {
        // appsettings.json dosyasından ödeme yöntemi adını okuyoruz
        var paymentMethodName = _configuration["Payment:PaymentMethod"];

        // Namespace ile birlikte tam sınıf adı
        var fullyPaymentMethodClassName = $"{typeof(IPaymentMethod).Namespace}.{paymentMethodName}";

        // Reflection ile sınıfı oluşturuyoruz
        var paymentMethodType = Type.GetType(fullyPaymentMethodClassName);
        if (paymentMethodType == null)
        {
            throw new InvalidOperationException($"Geçersiz ödeme yöntemi: {paymentMethodName}");
        }

        // IPaymentMethod tipinde bir nesne oluşturuyoruz
        var paymentMethodInstance = Activator.CreateInstance(paymentMethodType) as IPaymentMethod;
        return paymentMethodInstance ?? throw new InvalidOperationException("Ödeme yöntemi oluşturulamadı.");
    }
}
