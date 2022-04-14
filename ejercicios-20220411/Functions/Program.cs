// See https://aka.ms/new-console-template for more information


//Distinct solo traera un elemento unico en el listado aun si se repiten
int[] factoriales = { 2, 2, 3, 5, 5 };
int factorialesUnicos = factoriales.Distinct().Count();

Console.WriteLine($"Hay {factorialesUnicos} factoriales unicos");

//suma de elementos
int[] numbers = { 5, 4, 1, 4, 6, 34 };
double numSum = numbers.Sum();

Console.WriteLine($"La suma de elementos es: {numSum}");

//El valor minimo dentro de un listado
int[] numbers2 = { 5, 4, 1, 4, 6, 34 };
int minNum = numbers.Min();
int maxNum = numbers.Max();

Console.WriteLine($"El numero mas chico es: {minNum}");
Console.WriteLine($"El numero mas grande es: {maxNum}");

//Proyecciones en min y max
string[] words = { "cherry", "apple", "banana" };
int shortestWord = words.Min(w => w.Length);
int longestWord = words.Min(w => w.Length);

Console.WriteLine($"La palabra mas corta tiene: {shortestWord} caracteres");
Console.WriteLine($"La palabra mas larga tiene: {longestWord} caracteres");

//promedio en un listado
double averageNum = numbers.Average();
Console.WriteLine($"El promedio es: {averageNum}");

//proyecciones en average
double averageLenght = words.Average(w => w.Length);
Console.WriteLine($"El promedio de caracteres es: {averageLenght}");

//conversion de listas
double[] doubles = { 1.4, 5.3, 5.2, 6.4 };
var sortedDoubles = doubles.OrderBy(d => d);

var doublesArray = sortedDoubles.ToArray();

for (int i = 0; i < doublesArray.Length; i++)
{
	Console.WriteLine(doublesArray[i]);
}

var doublesList = sortedDoubles.ToList();

foreach (var d in doublesList)
	Console.WriteLine(d);

//conversion a diccionario
//El diccionario es una coleccion de llave y valor
var scoreRecord = new[]
{
	new {Name = "Alice", Score = 50},
	new {Name = "Bob", Score = 40},
	new {Name = "Cathy", Score = 45}
};

var scoreRecordDict = scoreRecord.ToDictionary(sr => sr.Name);

Console.WriteLine($"Bobs score: {0}", scoreRecordDict["Bob"]);

//Convertir datos obtenidos
object[] numbersObjects = { null, 1.0m, "two", 3, "four", 5, "six", 7.0d };

var doublesObjects = numbersObjects.OfType<double>();

Console.WriteLine("Numeros guardados como dobles");
foreach (var d in doublesObjects)
{
	Console.WriteLine(d);
}

var stringObjects = numbersObjects.OfType<string>();

Console.WriteLine("Numeros guardados como strings");
foreach (var d in stringObjects)
{
	Console.WriteLine(d);
}

//Un elemento del listado
string[] strings = { "zero", "one", "two", "three", "four", "five" };

var theFirstOne = strings.First();
var theOne = strings.First(c => c == "one");

Console.WriteLine($"El primer elemento de la lista es: {theFirstOne}");
Console.WriteLine($"El primer elemento de la lista que coincide con 'One' es: {theOne}");

//Tal vez exista un elemento del listado (es para que no truene si no encuentra elemento)
string[] strings2 = { };
var maybeTheFirstOne = strings2.FirstOrDefault();

//si el listado no tiene valores se le asigna el valor de hola
strings2.DefaultIfEmpty("hola").First();

//Obtener un objeto de la posicion de un listado
int[] numbers3 = { 5, 4, 1, 4, 6, 34 };
var inPosition = numbers3.ElementAt(2);

Console.WriteLine("Numero en la posicion 2 es:" + inPosition);

//ordenamiento de listados
var sortedStringsAsc = strings.OrderBy(c => c);
var sortedStringsDesc = strings.OrderByDescending(c => c);
var sortedMultipleTimes = strings
	.OrderBy(c => c[0])
	.ThenBy(c => c.Length);


//Toma la lista y las ordena al reves
var sortedReverse = strings.Reverse();

Console.WriteLine("El orden al reves de la lista es:");
foreach (var s in sortedReverse)
{
	Console.WriteLine(s);
}

//particiones de una lista
int[] numbers4 = { 5, 4, 1, 8, 6, 4, 9, 0 };
var first3Numbers = numbers4.Take(3);

Console.WriteLine("Los primeros 3 numeros:");
foreach (var number in first3Numbers)
{
	Console.WriteLine(number);
}

var takeWhile = numbers4.TakeWhile(c => c > 3);
Console.WriteLine("Tomara mientras la condicion de que el numero sea mayor a 3 se cumpla");
foreach (var number in takeWhile)
{
	Console.WriteLine(number);
}

var allButFirst4Numbers = numbers4.Skip(4);
Console.WriteLine("Los elementos despues de los primeros 4 son:");
foreach (var number in allButFirst4Numbers)
{
	Console.WriteLine(number);
}

var skipWhile = numbers4.SkipWhile(c => c > 2);
Console.WriteLine("Los elementos que fueron brincados mientras se cumplia la condicion de ser mayores que 2 son:");
foreach (var number in skipWhile)
{
	Console.WriteLine(number);
}

//Proyecciones
//Se crea listado a partir de una clase anonima
var selectList = strings.Select(c => new { Lenght = c.Length, Word = c });
//Se crea listado a partir de una clase definida
//var selectListWithEntity = strings.Select(c => new MyWord{Lenght = c.Lenght, Word = c});

foreach (var str in selectList)
{
	Console.WriteLine($"La palabra: {str.Word} tiene {str.Lenght}");
}

//contains
//regresa un booleano si la condicion se cumple
var siExisteZero = strings.Contains("zero");
//equals
//Any se cumple si cualquier elemento es igual a three
var esEqualAThree = strings.Any(c => c.Equals("Three"));
//concat
int[] nums1 = { 1, 2, 3 };
int[] nums2 = { 4, 5, 6 };

foreach (var n in nums1.Concat(nums2))
{
	Console.WriteLine(n);
}
