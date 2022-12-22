using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.OCP
{
    public class OCPBadSamples
    {
        // bir kod gelişime açık değişime kapalı olmalıdır
        // bir revize geldiğinde varolan kodumuz içerisinde if kullanarak bir çözüme gidiyorsak, ve bu revize bir işin farklı şekillerdeki yapılışı ile ilgileniyorsa OCp ters düşmüşüzdür.

        // Ödeme işlemi var
        // EFT, HAVALE
        // Çek ile Ödeme revizesi gelince kodunuza Ödemetipi diye bir alan açıp kodu revize ederek aynı method içerisinde çözüyorsak yanlış.

        // Çözüm => Interface veya Abstract bir sınıf ile arayüz oluşturmak ve bu arayüzden türeyen sınıflar ile çalışmak.

        public enum PurchaseOrderTypes
        {
            EFT=0,
            Havale=1,
            Checque =3
        }

        public class PurchaseOrder
        {
            private PurchaseOrderTypes _purchaseOrderTypes;
            public PurchaseOrder(PurchaseOrderTypes purchaseOrderTypes)
            {
                _purchaseOrderTypes = purchaseOrderTypes;
            }

            private void ApplyPayment()
            {

            }

            // EFT
           public void OnProcess(string toAccountNumber, string fromAccountNumber, double payableAmount)
            {

                switch (_purchaseOrderTypes)
                {
                    case PurchaseOrderTypes.EFT:
                        break;
                    case PurchaseOrderTypes.Havale:
                        break;
                    case PurchaseOrderTypes.Checque:
                        break;
                }  

            }
        }

    }
}
