using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SolidPrinciples.OCP.OCPBestSamples;

namespace SolidPrinciples.DIP
{
    class DIPBestSamples
    {

        public class PurchaseOrderManager : IPurchaseOrder
        {
            private IPurchaseOrder _purchaseOrder;

            //services.addScope<IPurchaseOrder,TransferPruchaseOrder>();

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
