using ORT.Vet.IBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using ORT.Vet.Domain;

namespace ORT.Vet.BusinessLogic
{
    public class PetLogic : IBusinessLogic<Pet>
    {
        private List<Pet> _pets = new List<Pet>() { new Pet() { Id = 1, Name = "Jaime", Age = 12 } };

        public List<Pet> GetAll()
        {
            return _pets;
        }

        public Pet GetById(int id)
        {
            return _pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet Create(Pet pet)
        {
            pet.Id = _pets.Any() ? _pets.Max(p => p.Id) + 1 : 1;
            _pets.Add(pet);
            return pet;
        }

        public Pet Update(int id, Pet updatedPet)
        {
            var pet = _pets.FirstOrDefault(p => p.Id == id);
            if (pet != null)
            {
                pet.Name = updatedPet.Name;
                pet.Age = updatedPet.Age;
            }
            return pet;
        }

        public bool Delete(int id)
        {
            var pet = _pets.FirstOrDefault(p => p.Id == id);
            if (pet != null)
            {
                _pets.Remove(pet);
                return true;
            }
            return false;
        }
    }
}
