using System.Collections.Concurrent;
using System.Diagnostics;
using Bogus;

public static class SolutionToQuestion5
{
    private static Faker faker = new Faker();

    public static async Task RunExample()
    {
        var people = GeneratePeople();
        var five = await FindFive(people);

        foreach (var person in five)
        {
            Console.WriteLine($"Id: {person.Id},FirstName: {person.FirstName},LastName: {person.LastName}");
        }
    }

    public static Person[] GeneratePeople()
    {
        var n = 8_000_000;
        return Enumerable.Range(1, n).Select(id => new Person()
        {
            Id = id,
            FirstName = faker.Name.FirstName(),
            LastName = faker.Name.LastName(),
        }).ToArray();
    }

    public static async Task<List<Person>> FindFive(Person[] people)
    {
        IEnumerable<(Task<bool> verify,Person p)> tasks = people.Select(p => (Verify(p.FirstName),p));

        var queue = new ConcurrentQueue<Person>();

        Parallel.ForEach(tasks, (async (tuple, state) =>
        {
            var result = await tuple.verify;
            if (result)
            {
                queue.Enqueue(tuple.p);
                if (queue.Count >= 5)
                {
                    state.Break();
                }
            }
        }));
        return queue.Take(5).ToList();
    }


    static async Task<bool> Verify(string firstName)
    {
       
        await Task.Delay(1000);

        return faker.Random.Bool();
    }
}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}