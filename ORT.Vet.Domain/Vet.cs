namespace ORT.Vet.Domain;

public class Vet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Pet> Pets { get; set; }  // Múltiples mascotas por veterinario
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
