// See https://aka.ms/new-console-template for more information
Programa prueba = new Programa();

prueba.ImprimeLlaveAgrupacion();


class Programa
{
    private static List<Student> students = new List<Student>
    {
        new Student {FirstName="Svetlana", LastName="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
        new Student {FirstName="Claire", LastName="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
        new Student {FirstName="Sven", LastName="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
        new Student {FirstName="Cesar", LastName="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
        new Student {FirstName="Debra", LastName="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
        new Student {FirstName="Fadi", LastName="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
        new Student {FirstName="Hanying", LastName="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
        new Student {FirstName="Hugo", LastName="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
        new Student {FirstName="Lance", LastName="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
        new Student {FirstName="Terry", LastName="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
        new Student {FirstName="Eugene", LastName="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
        new Student {FirstName="Michael", LastName="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
    };

    public void Prueba()
    {
        //Usando linq para objetos en formato query
        int[] scores = { 94, 76, 95, 67, 45 };

        IEnumerable<int> scoreQuery = from score in scores
                                      where score > 70
                                      select score * score;

        //Usando metodos de extension y expresiones Lambda
        var scoreQueryLambda = scores
            .Where(score => score > 70)
	        .Select(score => score * score);

        foreach (var i in scoreQuery)
        {
            Console.Write(i + " ");
        }
    }

    public void ImprimeCalificaciones()
    {
        var studentQuery =
            from student in students
            where student.Scores[0] > 90 && student.Scores[3] < 80
            orderby student.Scores[0] descending
            select student;

        var studentQueryLambda = students
            .Where(student => student.Scores[0] > 90 && student.Scores[3] < 80)
            .OrderBy(student => student.Scores[0]);

        //All solo regresa si la condicion se cumple para todos los elementos de la lista
        var studentQueryLambda2 = students
	    .Where(student => student.Scores.All(score => score > 80))
        //All solo regresa si la condicion se cumple para todos los elementos de la lista
        //.Where(student => studentScores.Any(score => score > 80))
        .OrderByDescending(student => student.Scores[0]);

        foreach (var student in studentQuery)
        {
            Console.WriteLine(student.LastName + " " + student.FirstName + " " + student.Scores[0]);
        }
    }

    public void ImprimeLlaveAgrupacion()
    {
        //Tambien se pueden agrupar los elementos usando groupby
        var studentQuery2 =
            from student in students
            group student by student.LastName[0]
            into studentGroup
            orderby studentGroup.Key
            select studentGroup;

        var studentQueryLambda2 = students
            .GroupBy(student => student.LastName[0])
            .OrderBy(group => group.Key);

        foreach (var studentGroup in studentQuery2)
        {
            Console.WriteLine(studentGroup.Key);

            foreach (var student in studentGroup)
            {
                //usaremos interpolacion de strings
                Console.WriteLine($"{student.LastName} {student.FirstName}");

                //sin interpolacion de strings
                //Console.WriteLine("nombre:" +student.LastName+ " apellido: " +student.FirstName);

            }
        }
    }

    public void ImprimePorCalificaciones()
    {
        //Se puede utilizar linq para realizar operaciones dentro de la comparacion y ademas regresar el valor deseado ya formateado

        IEnumerable<string> studentQuery3 = from student in students
                                            let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                                            where totalScore / 4 < student.Scores[0]
                                            select $"{student.FirstName} {student.LastName}";

        var studentQueryLambda3 = students
            .Where(student => (student.Scores[0] + student.Scores[1] + student.Scores[3] / 4 < student.Scores[0]))
            .Select(student => $"{student.FirstName} {student.LastName}");

        foreach (var student in studentQuery3)
        {
            Console.WriteLine(student);
        }

        //---------------------------------------------------------------------------	
        IEnumerable<string> studentQuery4 = from student in students
                                            let totalScore = student.Scores.Sum()
                                            where totalScore / 4 < student.Scores[0]
                                            select $"{student.FirstName} {student.LastName}";

        var studentQueryLambda4 = students
            .Where(student => (student.Scores.Sum() / 4 < student.Scores[0]))
            .Select(student => $"{student.FirstName} {student.LastName}");

        foreach (var student in studentQuery4)
        {
            Console.WriteLine(student);
        }
    }

    public void ImprimePromedio()
    {
        IEnumerable<string> studentQuery5 = from student in students
                                            let totalScore = student.Scores.Average()
                                            where totalScore / 4 < student.Scores[0]
                                            select $"{student.FirstName} {student.LastName}";

        IEnumerable<string> studentQueryLambda5 = students
            .Where(student => student.Scores.Average() < student.Scores[0])
            .Select(student => $"{student.FirstName} {student.LastName}");

        //sacar el promedio general de toda la clase
        var promedio = students.Average(student => student.Scores.Average());

        //Tambien se pueden hacer consultas linq con variables externas a ellas
        var lastName = "Garcia";
        var studentQuery6 = from student in students
                            where student.LastName.Equals(lastName)
                            select student.FirstName;

        var studentQueryLambda6 = students
            .Where(student => student.LastName.Equals(lastName))
            .Select(student => student.FirstName);

        Console.WriteLine("Todos los Garcias de la clase son:");
        Console.WriteLine(string.Join(", ", studentQuery6));
    }

    public void ImprimeNuevoObjeto()
    {
        //podemos crear tambien nuevos objetos a partir de nuestra consulta
        var studentQuery7 = from student in students
                            let totalScore = student.Scores.Sum()
                            where totalScore > promedio
                            select new { Id = student.ID, Score = totalScore };

        var studentQueryLambda7 = students
            .Where(student => student.Scores.Sum() > promedio)
            .Select(student => new
            {
                Id = student.ID,
		        Score = student.Scores.Sum()

            });

        //var primerEstudianteFiltrado = studentQueryLambdaX.Where(c => c.ID > 1000).FirstOrDefault();
        //var primerEstudianteFiltrado = studentQueryLambdaX.First();
        //var ultimoEstudianteFiltrado = studentQueryLambdaX.Last();

        //Student primerEstudianteFiltradoSinResultados = studentQueryLambdaX
        //    .Where(c => c.ID > 1000)
        //    .FirstOrDefault();
        //Console.WriteLine(primerEstudianteFiltradoSinResultados == null ? "es nulo" : primerEstudianteFiltradoSinResultados.FirstName);

        foreach (var item in studentQuery7)
        {
            Console.WriteLine($"Student id: {item.Id} Score: {item.Score}");
        }
    }
}

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ID { get; set; }
    public List<int> Scores { get; set; }
}
