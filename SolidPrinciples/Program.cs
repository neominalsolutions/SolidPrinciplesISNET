using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SolidPrinciples.LSP.LSPBadSamples;
using static SolidPrinciples.LSP.LSPBestSamples;
using static SolidPrinciples.OCP.OCPBestSamples;
using static SolidPrinciples.SRP.SRPBestSamples;

namespace SolidPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {

            // SRP BEST

            // Siparis arayuzden çağırma
            var cartSession = new CartSession();
            var cService = new CartService(cartSession);
            cService.AddToCart(new Cart());
            var cart = cService.Cart;
            

            var oInputModel = new OrderInputModel();
            oInputModel.Cart = cart;

            var oService = new OrderService();
            oService.DoOrder(oInputModel);


            // OCP BEST

            // Purchase Order Manager Router görevi görüp hangi sınıfın hangi casede çalışacağına karar verir.

            var poManager = new PurchaseOrderManager(new EFTPurchaseOrder());
            poManager.OnProcess("ali", "ahmet", 1000);

            poManager = new PurchaseOrderManager(new TransferPruchaseOrder());
            poManager.OnProcess("mert", "ali", 200);

            poManager = new PurchaseOrderManager(new ChequePurchaseOrder());
            poManager.OnProcess("mert", "ali", 200);


            poManager = new PurchaseOrderManager(new CanadaPurchaseOrder());
            poManager.OnProcess("mert", "ali", 200);

            // DIP Bad 

            // tight coupling
            DIP.DIPBadSamples.PurchaseOrderManager poManager2 = new DIP.DIPBadSamples.PurchaseOrderManager(OCP.OCPBadSamples.PurchaseOrderTypes.Checque);

            poManager2.OnProcess("ali", "ayse", 1400);

            // DIP BEST

            // loose coupling
            DIP.DIPBestSamples.PurchaseOrderManager poManager3 = new DIP.DIPBestSamples.PurchaseOrderManager(new EFTPurchaseOrder());
            poManager3.OnProcess("mert", "ali", 200);


            // DI Sample


            //1. Tercih
            // constructor Injection ile Logger koda enjecte ettik
            DI.DIBadSamples.LogManager text = new DI.DIBadSamples.LogManager(new DI.DIBadSamples.TextLogger()); // constructor injection
            text.LogText(new DI.DIBadSamples.TextLogger());

            //2.Tercih
            // property Injection ile Logger koda enjecte ettik
            DI.DIBadSamples.LogManager db = new DI.DIBadSamples.LogManager();
            db.LogDatabase(new DI.DIBadSamples.DatabaseLogger()); // method injection
    


     

            //3.Tercih
            // method Injection ile Logger koda enjecte ettik
            DI.DIBadSamples.LogManager pdf3 = new DI.DIBadSamples.LogManager(new DI.DIBadSamples.TextLogger());
            db.Log();



            // DI Best Practice

            //3.Tercih
            // method Injection ile Logger koda enjecte ettik
            DI.DIBestSamples.LogManager pdf4 = new DI.DIBestSamples.LogManager(new DI.DIBestSamples.DBLogger());
            db.Log();
            DI.DIBestSamples.LogManager pdf5 = new DI.DIBestSamples.LogManager(new DI.DIBestSamples.TextLogger());
            db.Log();


            // BAD LSP

            /*

            var triangle = new BadSquare();
            triangle.Height = 100;
            triangle.Width = 50; // bu bir kenar aslında

            double result =  triangle.GetPerimeter(50,10,60);

            var square = new BadTriangle();
            square.Height = 100;
            square.Width = 120; // bu neden var yada ismi neden widthHeight

            square.GetPerimeter(); // parameterles


            // Concreate sınıflar olan Triangle ve Square birbileri yerine kullanılamıyor.

            */





        }
    }
}
