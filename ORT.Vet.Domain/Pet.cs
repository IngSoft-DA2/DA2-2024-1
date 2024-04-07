namespace ORT.Vet.Domain;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int OwnerId { get; set; }
    public Owner Owner { get; set; }  // Navigation property for one-to-one or one-to-many
    public ICollection<Vet> Vets { get; set; }  // Múltiples veterinarios por mascota
    
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

}
