// See https://aka.ms/new-console-template for more information
//Func recibe y regresa valores
Func<int, int> square = x => x * x;

//Action solo recibe valores
Action<string> action = x => Console.WriteLine(x);

Console.WriteLine(square(5));
action("Hola mundo");

int[] numbers = { 1, 3, 6, 8 };
var squaredNumbers = numbers.Select(x => x * x);

Console.WriteLine(String.Join(",", squaredNumbers));

//---------------------------------------------------------------------------
//Los action pueden tambien declararse sin variables de entrada
Action line = () => Console.WriteLine("Hola");

Func<int, int, string> IsTooLong = (x, y) => x > y ? "es mayor" : "es menor";
Console.WriteLine(IsTooLong(20, 15));

//---------------------------------------------------------------------------
var tuplas = MisTuplas();

Console.WriteLine(tuplas.Item1 + " Mensaje: " + tuplas.Item2);
Console.WriteLine(tuplas.EsCorrecto + " Mensaje: " + tuplas.Mensaje);

static (bool EsCorrecto, string Mensaje) MisTuplas()
{
	return (true, "mensaje de prueba");
}

public class MiClase
{
	public bool Resultado { get; set; }
	public String Mensaje { get; set; }
}

//---------------------------------------------------------------------------
//Func<int, int, (bool, string)> MiFunc = (x, y) => (x > y, "Mi mensaje");

Func<int, int, (bool EsCorrecto, string Mensaje)> MiFunc2 = (x, y) => (x > y, "Mi mensaje");
var aux = MyFunc2(1, 2);
Console.WriteLine(aux.Mensaje);

//---------------------------------------------------------------------------
//Se pueden usar delegados con parametros descartados (c# 9)
Func<int, int, int> constant = (_, _) => 42;
Action<int, int> constant2 = (_, _) => Console.WriteLine(43);

//---------------------------------------------------------------------------
//Un action con serie de declaraciones
Action<int> miAccionAsincrona = miParametro =>
{
	Task.Delay(2000);
	Console.WriteLine("Me espere 2000 milisegundos");
}

//Un action con metodo asincrono
action<int> miOtraAccionAsincrona = async parametro => await DelayConImpresion(parametro);

static async Task DelayConImpresion(int x)
{
	await Task.Delay(2000);
	Console.WriteLine("Me espere 2000 milisegundos e imprimi " + x);
}

//---------------------------------------------------------------------------
//Meotod con cuerpo de expresion
static string IsTooLong2(int x, int y) => x > y ? "es mayor" : "es menor";
Console.WriteLine(IsTooLong2(20, 15));
