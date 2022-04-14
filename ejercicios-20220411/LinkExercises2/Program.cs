// See https://aka.ms/new-console-template for more information

// C.1 Write a program in C# Sharp to display the number and frequency of number from given array.
// C.2 Write a program in C# Sharp to display a list of unrepeated numbers.
// C.3 Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.

ListaNumeros prueba = new ListaNumeros();
prueba.Exercise1();
prueba.Exercise2();
prueba.Exercise3();

class ListaNumeros
{
	int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };

	public void Exercise1()
    {
		Console.WriteLine("\n");
		
		var query = arr1
			.GroupBy(c => c)
			.Select(g => new
			{
				Number = g.Key,
				Frequency = g.Count()
			});

		foreach (var number in query)
		{
			Console.WriteLine($"Number: {number.Number} Frequency: {number.Frequency}");
		}
	}

	public void Exercise2()
    {
		Console.WriteLine("\n");

		var query = arr1
			.GroupBy(n => n)
			.Where(n => n.Count() == 1)
			.Select(n => n);

		Console.WriteLine(string.Join(", ", query));
	}

	public void Exercise3()
    {
		var operations = arr1
			.GroupBy(n => n)
			.Select(num => new
			{
				number = num.Key,
				multiplication = num.Key * num.Count(),
				frecuency = num.Count()
			});

		foreach (var item in operations)
		{
			Console.WriteLine($"Numero: {item.number} Multiplicacion: {item.multiplication} Frecuencia: {item.frecuency}");
		}
	}
}