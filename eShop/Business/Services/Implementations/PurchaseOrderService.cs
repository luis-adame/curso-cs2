using Data.Entities;
using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class PurchaseOrderService
    {
        private List<PurchaseOrder> _purchaseOrders = new List<PurchaseOrder>();

        //public void AddPurchaseOrder(PurchaseOrder purchaseOrder)
        //{
        //    _purchaseOrders.Add(purchaseOrder);
        //}

        public void AddPurchaseOrder(PurchaseOrder purchaseOrder) => _purchaseOrders.Add(purchaseOrder);

        //public List<PurchaseOrder> GetPurchaseOrders()
        //{
        //    return _purchaseOrders;
        //}

        public List<PurchaseOrder> GetPurchaseOrders() => _purchaseOrders;

        public PurchaseOrder ChangeStatus(int purchaseOrderId, PurchaseOrderStatus status)
        {
            var po = _purchaseOrders.FirstOrDefault(c => c.Id == purchaseOrderId);

            if (po != null)
            {
                po.ChangeOrderStatus(status);
                return po;
            }
            else
            {
                throw new ApplicationException("No se encontro la orden solicitada");
            }
        }

    }
}
