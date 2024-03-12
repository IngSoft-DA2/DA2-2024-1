using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ORT.Vet.WebApi.Controllers;

// 1. Postman GET http:localhost:5051/api/pets
// 2. .NET mira la ruta (/api/pets) -> PetController
// 3. new PetController()
// 4. .NET mira el verbo HTTP
// 5. En conjunto a la ruta y el verbo decide que metodo ejecutar

// endpoint -> metodo

// Ejercicio para uds:
// 1 - Correr y probar todos los endpoints
// 2 - Cambiar PUT a PATCH
// 3 - Agregarle al perro color de pelo y probar todos los endpoints

[ApiController]
[Route("api/pets")]
public class PetController : ControllerBase
{
    public static List<Pet> _pets = new List<Pet>() { new Pet() { Id = 1, Name = "Jaime", Age = 12}};
    
    // GET api/pets
    [HttpGet]
    public IActionResult Index()
    {
        // 200
        return Ok(_pets);
    }
    
    
    // GET api/pets/{id}
    [HttpGet("{id}")]
    public IActionResult Show([FromRoute] int id)
    {
        var pet = _pets.Find(p => p.Id == id);

        if (pet != null)
        {
            // 200
            return Ok(pet);
        }
        else
        {
            // 404
            return NotFound(new { Message = $"No se encontro el perro con id {id}"});
        }
    }
    
    // POST api/pets
    [HttpPost]
    // MODEL BINDING
    public IActionResult Create([FromBody] Pet newPet)
    {
        if (String.IsNullOrEmpty(newPet.Name))
        {
            // 400
            return BadRequest(new { Message = "Falta el nombre :(" });
        }

        newPet.Id = _pets.Count + 1;
        _pets.Add(newPet);
        
        // 200
        return Ok(newPet);
    }
    
    // PUT api/pets/{id}
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Pet updatedPet)
    {
        var pet = _pets.Find(p => p.Id == id);
        
        if (pet == null)
        {
            // 404
            return NotFound(new { Message = "No encontre el perro"});
        }
        
        // Saco de la lista y agrego denuevo pero actualizo
        // SOLO porque no estoy usando BD y la lista no tiene metodo update
        var petToInsert = new Pet()
        {
            Id = pet.Id,
            Name = updatedPet.Name,
            Age = updatedPet.Age
        };
        _pets.Remove(pet);
        _pets.Add(petToInsert);

        return Ok(petToInsert);
    }
    
    // DELETE api/pets/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var pet = _pets.Find(p => p.Id == id);

        if (pet == null)
        {
            // 404
            return NotFound(new { Message = "No encontre el perro"});
        }

        _pets.Remove(pet);
        
        // 204
        return NoContent();
    }
}

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
