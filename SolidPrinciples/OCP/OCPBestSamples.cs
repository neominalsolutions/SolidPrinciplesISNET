using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.OCP
{
    public class OCPBestSamples
    {

        public interface IPurchaseOrder
        {
            void OnProcess(string to, string from, double payableAmount);
        }


        public interface ICanadaPurchaseOrder: IPurchaseOrder
        {
            void OnAccountCheck(string to, string from, double payableAmount);
        }

        public class CanadaPurchaseOrder : ICanadaPurchaseOrder
        {
            public void OnAccountCheck(string to, string from, double payableAmount)
            {
                throw new NotImplementedException();
            }

            public void OnProcess(string to, string from, double payableAmount)
            {
                throw new NotImplementedException();
            }
        }

        public class ChequePurchaseOrder : IPurchaseOrder
        {
            public void OnProcess(string to, string from, double payableAmount)
            {
                throw new NotImplementedException();
            }
        }


        public class EFTPurchaseOrder : IPurchaseOrder
        {
            public void OnProcess(string to, string from, double payableAmount)
            {
                throw new NotImplementedException();
            }
        }

        public class TransferPruchaseOrder : IPurchaseOrder
        {
            public void OnProcess(string to, string from, double payableAmount)
            {
                throw new NotImplementedException();
            }
        }

        public class PurchaseOrderManager : IPurchaseOrder
        {
            private IPurchaseOrder _purchaseOrder;


            public PurchaseOrderManager(IPurchaseOrder purchaseOrder)
            {
                _purchaseOrder = purchaseOrder;
            }

            public void OnProcess(string to, string from, double payableAmount)
            {
                 _purchaseOrder.OnProcess(to, from, payableAmount);
            }
        }
    }
}
