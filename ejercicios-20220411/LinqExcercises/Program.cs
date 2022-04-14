// See https://aka.ms/new-console-template for more information

//Listas prueba = new Listas();
//prueba.Excercise1();
//prueba.Excercise2();
//prueba.Excercise3();

//Listas2 prueba = new Listas2 ();
//prueba.Excercise1();
//prueba.Excercise2();
//prueba.Excercise3();
//prueba.Excercise5 ();

Lista3 prueba = new Lista3 ();
prueba.Exercise1();
prueba.Exercise2();

class Listas
{   
        // Find the words in the collection that start with the letter 'L'
        List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

        // Which of the following numbers are multiples of 4 or 6
        List<int> mixedNumbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };

        // Output how many numbers are in this list
        List<int> numbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };
    

    public void Excercise1()
    {
        var query1 = fruits
            .Where(fruit => fruit[0].Equals('L'));

        foreach (var fruta in query1)
        {
            Console.WriteLine($"{fruta}");
        }
    }

    public void Excercise2()
    {
        var query1 = mixedNumbers
            .Where(number => number%4 == 0 || number%6 == 0);

        foreach (var numero in query1)
        {
            Console.WriteLine($"{numero}");
        }
    }

    public void Excercise3()
    {
        var query1 = mixedNumbers
            .Count();

        Console.WriteLine("Elementos: "+query1);
    }
}

class Listas2
{
    List<Customer> customers = new List<Customer>() {
        new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
        new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
        new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
        new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
        new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
        new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
        new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
        new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
        new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
        new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
    };

    //Despliega cuantos millonarios hay por banco
    public void Excercise1()
    {
        //var millonaireCustomers = customers
        //    .GroupBy(c => c.Bank)
        //    .Select(bank => new
        //    {
        //        Bank = bank.Key,
        //        Millonarios = bank.Where(c => c.Balance > 1000000)
        //    });

        //var millonarios = customers
        //    .Where(c => c.Balance > 1000000)
        //    .GroupBy(c => c.Bank)
        //    .Select(bank => new
        //    {
        //        Bank = bank.Key,
        //        Millonarios = bank.Count()
        //    });

        //Console.WriteLine(string.Join(", ", millonarios.Select(c => $"{c.Bank} {c.Millonarios}")));

        Console.WriteLine("\n");
        var query1 = customers
            .Count(customer => customer.Balance >= 1000000);

        Console.WriteLine($"Hay {query1} millonarios.");
    }

    //Mostrar clientes que su balance sea mayor a 100,000
    public void Excercise2()
    {
        //var result = customers
        //    .Where(c => c.Balance > 100000)
        //    .Select(c => c.Name);

        Console.WriteLine("\n");
        var query1 = customers
            .Where(customer => customer.Balance > 100000);

        foreach (var cliente in query1)
        {
            Console.WriteLine($"{cliente.Name} {cliente.Balance}");
        }
    }

    //Hay que ordenar a los clientes por su balance
    public void Excercise3()
    {
        //var result2 = customers
        //    .OrderBy(c => c.Balance);

        Console.WriteLine("\n");
        var query1 = customers
            .OrderBy(customer => customer.Balance);

        foreach (var cliente in query1)
        {
            Console.WriteLine($"{cliente.Name} {cliente.Balance}");
        }
    }

    //Hacer una sumatoria por riqueza por cada banco
    public void Excercise4()
    {
        //var result3 = customers
        //    .GroupBy(c => c.Bank)
        //    .Select(c => new
        //    {
        //        Bank = c.Key,
        //        Total = c.Sum(c => c.Balance)
        //    });

        //foreach (var c in result3)
        //{
        //    Console.WriteLine($"Banco: {c.Bank} Riqueza {c.Total}");
        //}
    }


    //Obtener el nombre de los clientes que su balance sea menor a 100,000 y su banco tenga solo 3 caracteres
    public void Excercise5()
    {
        //var result4 = customers
        //    .Where(c => c.Balance < 100000 && c.Bank.Lenght == 3)
        //    .Select(c => $"{c.Name}{c.Balance}{c.Bank}")

        //foreach (var c in result4)
        //{
        //    Console.WriteLine(c);
        //}

        Console.WriteLine("\n");

        var query1 = customers
            .Where(customer => customer.Balance < 100000 && customer.Bank.Count() == 3);

        foreach (var cliente in query1)
        {
            Console.WriteLine($"{cliente.Name} {cliente.Balance} {cliente.Bank}");
        }
    }
}

internal class Customer
{
    public string Name { get; internal set; }
    public double Balance { get; internal set; }
    public string Bank { get; internal set; }
}

class Lista3
{
    string[] cities = {"ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"};

    // B.1 Find the string which starts and ends with a specific character : AM
    // B.2 Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order.
    // B.3 Write a program in C# Sharp to split a collection of strings into 3 random groups.

    public void Exercise1()
    {
        Console.WriteLine("\n");
        var query = cities
            .Where(ciudad => ciudad.Substring(0,2).Equals("AM"));

        foreach (var a in query)
        {
            Console.WriteLine($"{a}");
        }
    }

    public void Exercise2()
    {
        Console.WriteLine("\n");
        var query = cities
            .OrderBy(ciudad => ciudad.Length)
            .OrderBy(ciudad => ciudad)
            .Select(ciudad => ciudad);

        foreach (var a in query)
        {
            Console.WriteLine($"{a}");
        }
    }
}