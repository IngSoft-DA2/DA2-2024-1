using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ORT.Vet.IBusinessLogic;
using ORT.Vet.Domain;
using ORT.Vet.BusinessLogic;
using ORT.Vet.WebApi.DTOs.In;
using ORT.Vet.WebApi.DTOs.Out;
using ORT.Vet.IBusinessLogic.CustomExceptions;
using ORT.Vet.WebApi.Filters;

namespace ORT.Vet.WebApi.Controllers
{

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
        private readonly IBusinessLogic<Pet> _petLogic;

        public PetController(IBusinessLogic<Pet> petLogic)
        {
            _petLogic = petLogic;
        }

        //localhost:5051/api/pets
        [HttpGet]
        public IActionResult Index()
        {
            var retrievedPets = _petLogic.GetAll();
            return Ok(retrievedPets.Select(p => new PetDetailModel(p)).ToList());
        }
        
        //localhost:5051/api/pets/{id}
        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            var pet = _petLogic.GetById(id);
            return Ok(new PetDetailModel(pet));
        }
        
        //localhost:5051/api/pets
        [HttpPost]
        [AuthenticationFilter]
        public IActionResult Create([FromBody] PetCreateModel newPet)
        {
        
            if (String.IsNullOrEmpty(newPet.Name))
            {
                return BadRequest(new { Message = "Falta el nombre :(" });
            }
        
            var createdPet = _petLogic.Create(newPet.ToEntity());
            return Ok(new PetDetailModel(createdPet));
        }
        
        
        // localhost:5051/api/pets/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PetUpdateModel updatedPet)
        {
            var pet = _petLogic.Update(id, updatedPet.ToEntity());
            if (pet == null) return NotFound(new { Message = "No encontre el perro" });
            return Ok(new PetDetailModel(pet));
        }
        
        // localhost:5051/api/pets/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _petLogic.Delete(id);
            if (!success) return NotFound(new { Message = "No encontre el perro" });
            return NoContent();
        }

        // localhost:5051/api/pets?age=5
        // [HttpDelete]
        // public IActionResult DeleteAllWithAge([FromQuery] int age)
        // {
        //     var pets = _petLogic.GetAll();
        //     var petsToDelete = pets.FindAll(p => p.Age == age);
        //     if (petsToDelete.Count == 0) return NotFound(new { Message = "No encontre perros con esa edad" });
        //     foreach (var pet in petsToDelete)
        //     {
        //         _petLogic.Delete(pet.Id);
        //     }
        //     return NoContent();
        // }
        // {
        //     return NoContent();
        // }
    }
}