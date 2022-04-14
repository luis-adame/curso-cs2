using Data.Entities;
using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//crear la clase parcial para las ordenes de compra
//crear objeto tipo producto con los datos del producto seleccionado
//registrar una orden de compra donde se pida un proveedor y un listado de producto con su stock

namespace eShop
{
    public partial class eShopConsole
    {
        public Boolean MenuCompraProductos()
        {
            Console.Clear();
            Console.WriteLine("1. Consultar Compras");
            Console.WriteLine("2. Comprar Producto");
            Console.WriteLine("3. Cambiar Estatus");
            Console.WriteLine("4. Salir");

            switch (Console.ReadLine())
            {
                case "1": ConsultaCompras();  break;
                case "2": ComprarProducto();  break;
                case "3": return false;
                default: break;
            }

            return true;
        }
        public void ComprarProducto()
        {
            Console.Clear();
            Console.WriteLine("Escriba datos del proveedor");

            Console.WriteLine("Id: ");
            var idProveedorCaptura = Console.ReadLine();

            if (!int.TryParse(idProveedorCaptura, out int idProveedorAux))
            {
                throw new ApplicationException("No se pudo castear el Id Correctamente");
            }

            Console.WriteLine("Nombre: ");
            var nombre = Console.ReadLine();

            Console.WriteLine("Correo: ");
            var correo = Console.ReadLine();

            Console.WriteLine("Telefono: ");
            var telefono = Console.ReadLine();

            Console.WriteLine("Direccion: ");
            var direccion = Console.ReadLine();

            Console.WriteLine("Ciudad: ");
            var ciudad = Console.ReadLine();

            var provider = new Provider(idProveedorAux, nombre, correo);
            provider.AddPhoneNumber(telefono);


            Console.Clear();
            Console.WriteLine("Seleccione producto");

            foreach (var a in _productService.GetProducts())
            {
                Console.WriteLine($"{a.Id}\t{a.Name}\t{a.Price}\t{a.Stock}\n");
            }

            var idProductoCaptura = Console.ReadLine();
            if (!int.TryParse(idProductoCaptura, out int idProductoAux))
            {
                throw new ApplicationException("No se pudo castear el Id Correctamente");
            }

            var productoSeleccionado = _productService.GetProduct(idProductoAux);

            if (productoSeleccionado != null)
            {
                List<Product> productosComprados = new List<Product>();
                productosComprados.Add(productoSeleccionado);

                var purchaseOrder = new PurchaseOrder(provider, productosComprados);

                _purchaseOrderService.AddPurchaseOrder(purchaseOrder);
            }
        }

        private void ConsultaCompras()
        {
            Console.Clear();
            Console.WriteLine("Lista de compras");

            foreach (var a in _purchaseOrderService.GetPurchaseOrders())
            {
                Console.WriteLine($"{a.PurchaseDate}\t{a.Total}\t");
            }

            Console.ReadLine();
        }

        private void CambiarEstatusOrdenCompra()
        {
            Console.WriteLine("A que orden quieres cambiarle el estatus?");
            var poId = int.TryParse(Console.ReadLine(), out int idNum) ? idNum: 0;

            Console.WriteLine("A que estatus quieres cambiarlo?");

            foreach (var status in Enum.GetNames<PurchaseOrderStatus>())
            {
                Console.WriteLine(status);
            }

            var statusAux = Console.ReadLine();

            PurchaseOrderStatus newStatus;
            var didParse = Enum.TryParse(statusAux, out newStatus);

            if (didParse)
            {
                var po = _purchaseOrderService.ChangeStatus(poId, newStatus);

                //actualizar (sumar) el stock de los productos originales que fueron comprados por la orden de comprados
                //que haya sido pagada
                if (po.Status == PurchaseOrderStatus.Ready)
                {
                    foreach (var pcsdProduct in po.PurchasedProducts)
                    {
                        _productService.GetProduct(pcsdProduct.Id).AddStock(pcsdProduct.Stock);
                    }
                }
                
                Console.WriteLine("Orden de compra actualizada correctamente");
            }
            else
            {
                Console.WriteLine("El estatus solicitado no existe");
            }

            Console.WriteLine();
        }
    }
}
