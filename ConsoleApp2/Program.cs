// See https://aka.ms/new-console-template for more information

var people = SolutionToQuestion5.GeneratePeople();
var five = await SolutionToQuestion5.FindFive(people);

foreach (var person in five)
{
    Console.WriteLine($"Id: {person.Id},FirstName: {person.FirstName},LastName: {person.LastName}");
}