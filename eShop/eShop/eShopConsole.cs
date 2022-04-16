using Business.Services;
using Business.Services.Implementations;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        private readonly ProductService _productService;
        private readonly DepartmentService _departmentService;
		private readonly ReportService _reportService;
		private readonly PurchaseOrderService _purchaseOrderService;
		private readonly ProviderService _providerService;

        public eShopConsole()
        {
            _productService = new ProductService();
            _departmentService = new DepartmentService();
			_reportService = new ReportService();
			_purchaseOrderService = new PurchaseOrderService();
			_providerService = new ProviderService();
		}

		public Boolean MainMenu()
		{
			Console.Clear();
			Console.WriteLine("Bienvenido al sistema de compras eShop, seleccione Usuario de inicio");
			Console.WriteLine("1. Cliente");
			Console.WriteLine("2. Administrador");

            switch (Console.ReadLine())
            {
				case "1": while(MenuCliente());
					break;
				case "2": while(MenuAdministrador());
					break;
				default:
					break;
            }

			return true;
		}
	}
}
