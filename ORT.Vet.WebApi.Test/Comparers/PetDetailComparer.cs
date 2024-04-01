using ORT.Vet.WebApi.DTOs.Out;

namespace ORT.Vet.WebApi.Test.Comparers;

public class PetDetailComparer : IEqualityComparer<PetDetailModel>
{
    public bool Equals(PetDetailModel? x, PetDetailModel? y)
    {
        return x?.Id == y?.Id;
    }

    public int GetHashCode(PetDetailModel obj)
    {
        return obj.GetHashCode();
    }
}