using Microsoft.Extensions.Configuration;
using OpenClosedPrinciple;

class Program
{
    static void Main(string[] args)
    {
        // IConfiguration'u yapılandırıyoruz
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // PaymentMethodFactory sınıfını oluşturuyoruz
        var paymentFactory = new PaymentMethodFactory(configuration);

        // Factory'den payment methodu oluşturuluyor
        var paymentMethod = paymentFactory.CreatePaymentMethod();

        // Ödeme işlemini gerçekleştiriyoruz
        paymentMethod.ProcessPayment(100m);
    }
}
