namespace ORT.Vet.Domain;

public class Appointment
{
    public int PetId { get; set; }
    public Pet Pet { get; set; }
    public int VetId { get; set; }
    public Vet Vet { get; set; }
    public DateTime Date { get; set; }
    public string Reason { get; set; }  // Detalle adicional como el motivo de la cita
}