public abstract class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Cat : Animal
{
    public bool IsIndoor { get; set; }
}

public class Dog : Animal
{
    public string Breed { get; set; }
}
