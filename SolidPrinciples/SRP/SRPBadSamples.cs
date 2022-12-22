using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.SRP
{
    public class SRPBadSamples
    {
        // bir sınıfın değişebilmesi için sadece tek bir nedenin olması gerekir.
        // Sorumlulukların ayrımı prensibi

        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }

        public class OrderTransaction
        {
            public decimal SalesPrice { get; set; }

            public List<Product> Products { get; set; }

            public string ShipAddress { get; set; }

            public string CustomerName { get; set; }

            public bool SendSms { get; set; }

            public bool SendEmail { get; set; }


            public void DoOrder()
            {
                // bankadan para çekme gerçekleşti
                // sipariş no oluşturduk
                // DB de tut (Transacation, Stock Management)
                // fatura kestik (FAturanın)
                // sms yada e-posta ile bilgilendirme (Altyapı servis)
                // 3000 satır
            }



        }

        // Gereksinimler

        // Sepet bilgilerini Session tutmak için ICartSessionS
        // Sepete bir ürün ekleme çıkarma vs operasyonlarının yönetimiş için CartManager
        // OrderInputModel => Ekrandan alınacak olan sipariş bilgileri
            // Musteri => 
                    // CustomerModel => CustomerAddressList
            // SendSms, SendEMail
            // CustomerCreditCardModel => CVV, Card Number, CardName, ValidThru
            // Cart => Sepet OrderInput Model içerisinden gönderilir

        // BankAPI => Ödeme işlemi için bir dönüş beklenir
        // IOrderApplicationService => DoOrder(OrderInput model) onProcess ile işler
        // Stock kontrolünü ProductNesnesi üzerinde yapar.
        // OrderHelper => OrderCode
        // IOrderRepo ile bu sipariş bilgileri DB aktarılır
        // InvoiceService => fatura oluşturulur
        // PDFGeneator (Invoice) generate edilir
        // SAP gibi sistemlere kayıt düşülüp Invoice gönderilir.
        // NotificationService => SMS veya EMail gönderilir.


      




    }

   


}
