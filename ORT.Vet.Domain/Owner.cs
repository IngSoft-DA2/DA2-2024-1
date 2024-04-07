namespace ORT.Vet.Domain;

public class Owner
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Pet> Pets { get; set; } = new List<Pet>();  // Relación 1-n con Pet
}
