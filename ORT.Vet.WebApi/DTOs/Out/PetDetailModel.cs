using System;
using ORT.Vet.Domain;

namespace ORT.Vet.WebApi.DTOs.Out
{
    public class PetDetailModel
    {
        public PetDetailModel(Pet pet)
        {
            Id = pet.Id;
            Name = pet.Name;
            Age = pet.Age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}