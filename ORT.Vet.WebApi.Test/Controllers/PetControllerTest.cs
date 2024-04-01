using Microsoft.AspNetCore.Mvc;
using ORT.Vet.Domain;
using ORT.Vet.IBusinessLogic;
using ORT.Vet.WebApi.Controllers;
using ORT.Vet.WebApi.DTOs.Out;
using Moq;
using ORT.Vet.WebApi.Test.Comparers;

namespace ORT.Vet.WebApi.Test;

[TestClass]
public class PetControllerTest
{
    private List<Pet> _pets;
    private Mock<IBusinessLogic<Pet>> _petLogicMock;
    
    [TestInitialize]
    public void Setup() 
    {
        _petLogicMock = new Mock<IBusinessLogic<Pet>>(MockBehavior.Strict);
        _pets = new List<Pet>() { new Pet() { Id = 1, Name = "Kila", Age = 2 } };
    }
    
    [TestMethod]
    public void IndexOkTest() 
    {
        // Arrange
        _petLogicMock.Setup(r => r.GetAll()).Returns(_pets);
        var controller = new PetController(_petLogicMock.Object);
    
        // Act
        var result = controller.Index();
        var okResult = result as OkObjectResult;
        List<PetDetailModel> petModels = okResult.Value as List<PetDetailModel>;
        List<PetDetailModel> expectedModels = _pets.Select(p => new PetDetailModel(p)).ToList();

        // Assert
        _petLogicMock.VerifyAll(); // Verificar que se llamo a todos los métodos
        CollectionAssert.AreEqual(
            expectedModels,
            petModels
            );
    }

    [TestMethod]
    public void ShowOkTest()
    {
        // Arrange
        _petLogicMock.Setup(l => l.GetById(It.IsAny<int>())).Returns(_pets.First());
        var controller = new PetController(_petLogicMock.Object);
    
        // Act
        var result = controller.Show(_pets.First().Id);
        var okResult = result as OkObjectResult;
        var petModel = okResult.Value as PetDetailModel;
        PetDetailModel expectedPetModel = new PetDetailModel(_pets.First());

        // Assert
        _petLogicMock.VerifyAll(); // Verificar que se llamo a todos los métodos
        
        // Aca uso un equality comparer en lugar de basarme en el Equals y GetHashCode de PetDetailModel en sí
        Assert.AreEqual(expectedPetModel, petModel, new PetDetailComparer());
    }

    // [TestMethod]
    // [ExpectedException(typeof(Exception))]
    // public void PiquesDeMocksParaTestearLasOtrasCapas()
    // {
    //     var exception = new Exception();
    //     _petLogicMock.Setup(l => l.GetById(It.IsAny<int>())).Throws(exception);
    //     
    // }
}