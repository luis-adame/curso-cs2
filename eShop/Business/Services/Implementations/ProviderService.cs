using Business.Services.Abstractions;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class ProviderService : IProviderService
    {
        private List<Provider> ProviderList = TestData.GetProvidersData();

        public void AddProvider(Provider provider)
        {
            ProviderList.Add(provider);
        }

        public Provider GetProvider(int id)
        {
            return ProviderList.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
