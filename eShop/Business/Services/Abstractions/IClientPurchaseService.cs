﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    public interface IClientPurchaseService
    {
        public void AddPurchase(ClientPurchase purchaseOrder);
        public List<ClientPurchase> GetPurchases();
    }
}
