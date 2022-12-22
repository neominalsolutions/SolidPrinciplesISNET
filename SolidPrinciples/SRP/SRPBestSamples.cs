using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.SRP
{
    public class SRPBestSamples
    {

        // bir sınıfın değişebilmesi için sadece tek bir nedenin olması gerekir.
        // Sorumlulukların ayrımı prensibi

        // Avantajları
        // Test edilebilirlik (+)
        // Kod okunabilirliği (Zaman Maliyeti ^)
        // Kod kalitesi (+)

        // Dezavantajı
        // Ramde daha çok yer kaplayan bir modelleme (Storage Maliyeti)
        // Modellenmesinin karmaşık olması (Zaman Maliyeti aşağı yönlü)


        // Performance ile Management ters orantılı


        public class CartItem
        {
           
            public int Quantity { get; set; }
            public string ProductId { get; set; }

            public decimal ListPrice { get; set; }

          public decimal DiscountAmount { get; set; }

      }

        public class Cart
        {
            public string CartId { get; set; }
            public decimal TotalPrice { get; set; }

            public List<CartItem> CartItems { get; set; }

        }

        public interface ISession<T>
        {
            void SetSesion(T item);
            T GetSession();
        }

        public interface ICartSession : ISession<Cart>
        {

        }

        public class CartSession : ICartSession
        {
            public Cart GetSession()
            {
                throw new NotImplementedException();
            }

            public void SetSesion(Cart item)
            {
                throw new NotImplementedException();
            }
        }

        public interface ICartService
        {
            void AddToCart(Cart item);
            void DeleteFromCart(string productId);

            Cart Cart { get; }
        }

        /// <summary>
        /// Cart bilgilerini sessionda tuttuğumuz için DBde olmadığından sessionService kullanıyoruz.
        /// </summary>
        public class CartService : ICartService
        {
            private readonly ICartSession _session;
            public CartService(ICartSession session)
            {
                _session = session;
            }

            public Cart Cart { get; }

            public void AddToCart(Cart item)
            {
                _session.SetSesion(item);
                throw new NotImplementedException();
            }

            public void DeleteFromCart(string cartId)
            {
                throw new NotImplementedException();
            }

            
        }

        public struct CustomerAddress
        {
            public string ZipCode { get; set; }
            public string FullAddress { get; set; }

            public bool DefaultAddress { get; set; }
        }
        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public CustomerAddress ShipAddress { get; set; }

            public CustomerCreditCard Credit { get; set; }
        }

        public class CustomerCreditCard
        {
            public string OwnerName { get; set; }
            public string Cvv { get; set; }
            public string ValidThru { get; set; }
            public string CardNumber { get; set; }

        }

        public class OrderInputModel
        {
            public bool SendSms { get; set; }
            public bool SendEmail { get; set; }
            public Customer Customer { get; set; }

            public Cart Cart { get; set; }


        }


        // BankAPI => Ödeme işlemi için bir dönüş beklenir
        // IOrderApplicationService => DoOrder(OrderInput model) onProcess ile işler
        // Stock kontrolünü ProductNesnesi üzerinde yapar.
        // OrderHelper => OrderCode
        // IOrderRepo ile bu sipariş bilgileri DB aktarılır
        // InvoiceService => fatura oluşturulur
        // PDFGeneator (Invoice) generate edilir
        // SAP gibi sistemlere kayıt düşülüp Invoice gönderilir.
        // NotificationService => SMS veya EMail gönderilir.

        public class Order
        {
            public string OrderId { get; set; }
            public string ShipAddress { get; set; }

            public Nullable<DateTime> ShippedDate { get; set; }

            public List<OrderItem> OrderItems { get; set; }

            public string CustomerId { get; set; }
        }

        public class OrderItem
        {
        
            public string OrderId { get; set; }
            
            public int Quantity { get; set; }

            public string ProductId { get; set; }

            public decimal SalesUnitPrice { get; set; }


        }

        public class OrderRepo
        {
            public void Save(Order order)
            {
                // trasactionManagement
            }
        }

        public interface IGenerator
        {
            string Generate(byte[] data);
        }

        public class PdfGenerator : IGenerator
        {
            public string Generate(byte[] data)
            {
                throw new NotImplementedException();
            }
        }

        public static class OrderHelper
        {
            public static string GenerateCode()
            {
                return "";
            }
        }

        public enum PaymentStatus
        {
            OK=1,
            Rejected = 2,
            Limited=3
        }

        public class BankApi
        {
            public PaymentStatus Pay(decimal SalesPrice, CustomerCreditCard model)
            {
                return PaymentStatus.OK;
            }
        }

        public class NotificationService
        {
            public void Notify(string to, string from, string title, string message)
            {

            }
        }

        /// <summary>
        /// UI üzerinden sipariş verilince bu servis çalışıyor
        /// </summary>
        public class OrderService
        {
            private BankApi api;
            private PdfGenerator generator;
            private OrderRepo orderRepo;
            private NotificationService nfService;

            public OrderService()
            {
                api = new BankApi();
                generator = new PdfGenerator();
                orderRepo = new OrderRepo();
                nfService = new NotificationService();
            }

           public void DoOrder(OrderInputModel model)
            {
                var code = OrderHelper.GenerateCode();
                api.Pay(model.Cart.TotalPrice, model.Customer.Credit);
                generator.Generate(new byte[127]);

                // cart-> cartItems mapping to Order

                var order = new Order
                {
                    OrderId = Guid.NewGuid().ToString()

                };

                orderRepo.Save(order);

                nfService.Notify("ali", "ahmet", "siparis", "alındı");


            }
        }


    }
}
