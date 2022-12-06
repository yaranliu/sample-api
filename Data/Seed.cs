using Faker;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiSampleNoAuth.Data;

public class Seed
{

    private const string JsonFileName = "people.json";

    public Seed()
    {
        CreateJsonFile();
    }

    private string JsonPath => Path.Combine(Directory.GetCurrentDirectory(), JsonFileName);

    private void CreateJsonFile()
    {
        if (File.Exists(JsonPath)) return;
        var people = Enumerable
            .Range(1, 100)
            .Select(index =>
                new Person(index.ToString().PadLeft(4,'0'), Faker.Name.First(), Faker.Name.Last(), Faker.RandomNumber.Next(10, 200))
            ).ToList();
        var json = JsonConvert.SerializeObject(people);
        using var writer = File.CreateText(JsonPath);
        writer.WriteLine(json);
    }

    public List<Person> GetPeople()
    {
        CreateJsonFile();
        var text = File.ReadAllText(JsonPath);
        if (string.IsNullOrWhiteSpace(text)) return new List<Person>(); 
        var list = JsonConvert.DeserializeObject<List<Person>>(text);
        return list ?? new List<Person>();
    }
}