using Business.Services.Abstractions;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class ClientPurchaseService : IClientPurchaseService
    {
        private List<ClientPurchase> _purchaseOrders = new List<ClientPurchase>();

        public void AddPurchase(ClientPurchase purchaseOrder) => _purchaseOrders.Add(purchaseOrder);

        public List<ClientPurchase> GetPurchases() => _purchaseOrders;
    }
}
