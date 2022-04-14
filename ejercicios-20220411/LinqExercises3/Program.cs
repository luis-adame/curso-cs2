// See https://aka.ms/new-console-template for more information



// D.1 Get the top student of the list making an average of their scores.
// D.2 Get the student with the lowest average score.
// D.3 Get the last name of the student that has the ID 117
// D.4 Get the first name of the students that have any score more than 90

ListaAlumnos prueba = new();

prueba.Exercise1();

class ListaAlumnos
{
    List<Student> students = new List<Student>
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

    public void Exercise1()
    {
        //var query = students
        //.Max(student => student.Scores.Average());

        //Console.WriteLine($"{query}");

        var query = students
            .Select(student => student)
            .Where(student => student.Scores.Average() == students.Max(student => student.Scores.Average()));

        foreach (var a in query)
        {
            Console.WriteLine($"{a.FirstName} {a.LastName} Score: {a.Scores.Average()}");
        }
    }

    public void Exercise2()
    {

    }

    public void Exercise3()
    {
        var query = students.First(student => student.ID.Equals(117));
        Console.WriteLine($"{query.LastName}");
    }

    public void Exercise4()
    {
        var query = students
            .Where(student => student.Scores.Any(score => score > 90));

        foreach (var a in query)
        {
            Console.WriteLine($"Name: {a.FirstName} Scores: {string.Join(", ",a.Scores)}");
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