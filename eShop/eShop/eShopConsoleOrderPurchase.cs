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
        public Boolean MenuOrdenes()
        {
            Console.Clear();
            Console.WriteLine("ORDENES");
            Console.WriteLine("1. Consultar Pedidos");
            Console.WriteLine("2. Comprar Producto");
            Console.WriteLine("3. Cambiar Estatus de Pedido");
            Console.WriteLine("4. Salir");

            switch (Console.ReadLine())
            {
                case "1": ConsultaPedidos();  break;
                case "2": ComprarProducto();  break;
                case "3": CambiarEstatusPedido(); break;
                case "4": return false;
                default: break;
            }

            return true;
        }
        public void ComprarProducto()
        {
            var provider = SeleccionarProveedor();

            if (provider != null) {
                List<Product> productosComprados = new List<Product>();

                var opcion = "";

                do {
                    var producto = SeleccionarProducto();

                    if (producto != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Cuantas unidades desea comprar?");
                        var unidadesCaptura = Console.ReadLine();

                        if (int.TryParse(unidadesCaptura, out int unidades))
                        {
                            producto.AddStock(unidades);
                            productosComprados.Add(producto);
                        }
                    }
                    
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Desea comprar otro producto? (s/n)");
                        opcion = Console.ReadLine();
                    } while (opcion != "s" && opcion != "n");
                } while (opcion == "s");

                if(productosComprados.Count > 0)
                {
                    var purchaseOrder = new PurchaseOrder(provider, productosComprados);
                    _purchaseOrderService.AddPurchaseOrder(purchaseOrder);

                    Console.Clear();
                    Console.WriteLine("Pedido realizado exitosamente.");
                    Console.ReadKey();
                }
            }
        }

        private Provider SeleccionarProveedor()
        {
            Console.Clear();
            Console.WriteLine("Seleccionar No. de Proveedor");
            var idProveedorCaptura = Console.ReadLine();

            if (!int.TryParse(idProveedorCaptura, out int idProveedor))
                return null;

            Provider proveedor = _providerService.GetProvider(idProveedor);
            try
            {
                if (proveedor == null)
                {
                    Console.WriteLine("Escriba datos de nuevo proveedor");

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

                    proveedor = new Provider(nombre, correo);
                    proveedor.AddPhoneNumber(telefono);
                    proveedor.AddAddress(direccion, ciudad);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return proveedor;
        }

        private Product SeleccionarProducto()
        {
            Console.Clear();
            Console.WriteLine("Seleccione producto");

            foreach (var a in _productService.GetProducts())
            {
                Console.WriteLine($"Id:{a.Id}\tNombre:{a.Name}\tPrecio:{a.Price}\tStock:{a.Stock}");
            }

            var idProductoCaptura = Console.ReadLine();
            if (!int.TryParse(idProductoCaptura, out int idProductoAux))
                return null;

            var selected = _productService.GetProduct(idProductoAux);

            Product producto = new Product(selected.Id, selected.Name, 0, selected.Price, selected.Sku, selected.Description, selected.Brand);

            return producto;
        }

        private void ConsultaPedidos()
        {
            Console.Clear();
            Console.WriteLine("Lista de Pedidos");

            foreach (var orden in _purchaseOrderService.GetPurchaseOrders())
            {
                Console.WriteLine($"{orden.Id}\t{orden.PurchaseDate}\t{orden.Provider.Name}\t{orden.Total}\t{orden.Status}");
                foreach (var producto in orden.PurchasedProducts)
                {
                    Console.WriteLine($" - {producto.Name}\t{producto.Stock}\t{producto.Price}\tTotal:{producto.Stock * producto.Price}");
                }
            }

            Console.ReadKey();
        }

        private void CambiarEstatusPedido()
        {
            Console.Clear();
            Console.WriteLine("A que orden quieres cambiarle el estatus?");
            var poId = int.TryParse(Console.ReadLine(), out int idNum) ? idNum: 0;

            //_purchaseOrderService.GetPurchaseOrders();

            Console.Clear();
            Console.WriteLine("A que estatus quieres cambiarlo?");

            int i = 0;
            foreach (var status in Enum.GetNames<PurchaseOrderStatus>())
            {
                Console.WriteLine($"{i++}. {status}");
            }

            var statusAux = Console.ReadLine();

            PurchaseOrderStatus newStatus;
            var didParse = Enum.TryParse(statusAux, out newStatus);

            if (didParse)
            {
                try
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
                catch (Exception e)
                { 
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("El estatus solicitado no existe");
            }

            Console.ReadKey();
        }
    }
}
