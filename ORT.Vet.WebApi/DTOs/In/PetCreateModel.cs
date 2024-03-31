using System;
using ORT.Vet.Domain;

namespace ORT.Vet.WebApi.DTOs.In
{
    public class PetCreateModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Pet ToEntity()
        {
            return new Pet()
            {
                Name = this.Name,
                Age = this.Age
            };
        }
    }

}