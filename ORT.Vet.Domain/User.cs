namespace ORT.Vet.Domain;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    // No se preocupen por hashear
    public string Password { get; set; }
}
