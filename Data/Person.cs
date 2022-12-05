namespace ApiSampleNoAuth.Data;

public class Person
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Posts { get; set; }

    public Person(string id, string firstName, string lastName, int posts)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Posts = posts;
    }

    public override string ToString()
    {
        return $"{Id} {FirstName} {LastName} {Posts}";
    }
}