using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ORT.Vet.IBusinessLogic;
using ORT.Vet.Domain;

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

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_petLogic.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            var pet = _petLogic.GetById(id);
            if (pet != null) return Ok(pet);
            return NotFound(new { Message = $"No se encontro el perro con id {id}" });
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pet newPet)
        {
            if (String.IsNullOrEmpty(newPet.Name))
            {
                return BadRequest(new { Message = "Falta el nombre :(" });
            }

            var createdPet = _petLogic.Create(newPet);
            return Ok(createdPet);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Pet updatedPet)
        {
            var pet = _petLogic.Update(id, updatedPet);
            if (pet == null) return NotFound(new { Message = "No encontre el perro" });
            return Ok(pet);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _petLogic.Delete(id);
            if (!success) return NotFound(new { Message = "No encontre el perro" });
            return NoContent();
        }
    }
}