using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SolidPrinciples.OCP.OCPBadSamples;
using static SolidPrinciples.OCP.OCPBestSamples;

namespace SolidPrinciples.DIP
{
    // üst seviye sınıflar ile alt seviye sınıflar birbirine sıkı sıkıya bağlı olmamalıdır.
    // sınıflar arasındaki bağlantılar abstract sınıflardan veya interfacelerden oluşmalıdır ki sınıfların birbirine bağımlılığı zayıflamış olsun
    // DIP (Dependency Inversion Principle) => Bağımlılıkların Ters Çevrilmesi


    public class DIPBadSamples
    {

        // PurchaseOrderManager => üst sınıf
        // altsınıflar => EFTPurchaseOrder, TransferPruchaseOrder, ChequePurchaseOrder
        // bir üst sınıf bir alt sınıfı instance alıyor ve boşuna ram üzerinde referansları oluşuyor.
        // üst sınıf kendi işlemi dışınd alt sınıfların instance yönetimin yapıyor. 

        // DI => Dependency Injection
        // Bağımlıkların contructor, property setter, method parameter üzerinden koda enjekte edilmesine biz DI diyoruz.
        // Genelede bir işi birden fazla şekilde yapacak ise yani iş Polimorfişk bir yapıya sahip ise => ödeme emri örneği gibi. Bu durumda bu bağımlıkları bir arayüzden toplayabiliriz.

        public class PurchaseOrderManager 
        {
            private EFTPurchaseOrder _eftPurchaseOrder;
            private TransferPruchaseOrder _transferPurchaseOrder;
            private ChequePurchaseOrder _chequePurchaseOrder;
            private PurchaseOrderTypes _purchaseOrderTypes;


            public PurchaseOrderManager(PurchaseOrderTypes purchaseOrderTypes)
            {
                _eftPurchaseOrder = new EFTPurchaseOrder();
                _transferPurchaseOrder = new TransferPruchaseOrder();
                _chequePurchaseOrder = new ChequePurchaseOrder();
                _purchaseOrderTypes = purchaseOrderTypes;
            }

            public void OnProcess(string to, string from, double payableAmount)
            {


                switch (_purchaseOrderTypes)
                {
                    case PurchaseOrderTypes.EFT:
                        _eftPurchaseOrder.OnProcess(to, from, payableAmount);
                        break;
                    case PurchaseOrderTypes.Havale:
                        _transferPurchaseOrder.OnProcess(to, from, payableAmount);
                        break;
                    case PurchaseOrderTypes.Checque:
                        _chequePurchaseOrder.OnProcess(to, from, payableAmount);
                        break;
                    default:
                        break;
                }


            }
        }
    }
}
