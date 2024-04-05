using Microsoft.AspNetCore.Mvc;
using ORT.Vet.Domain;
using ORT.Vet.IBusinessLogic;
using ORT.Vet.WebApi.Controllers;
using ORT.Vet.WebApi.DTOs.Out;
using Moq;
using ORT.Vet.WebApi.Test.Comparers;
using System.Xml.Serialization;
using ORT.Vet.IBusinessLogic.CustomExceptions;

namespace ORT.Vet.WebApi.Test;

[TestClass]
public class PetControllerTest
{
    private Mock<IBusinessLogic<Pet>> _petLogicMock;

    [TestInitialize] 
    public void Setup()
    {
        _petLogicMock = new Mock<IBusinessLogic<Pet>>(MockBehavior.Strict);
    }

    [TestMethod]
    public void IndexOkTest()
    {
        // Arrange
        List<Pet> pets = new List<Pet>() { new Pet() { Id = 1, Name = "Kila", Age = 2 } };
        _petLogicMock.Setup(r => r.GetAll()).Returns(pets);
        var petController = new PetController(_petLogicMock.Object);
        var expectedContent = pets.Select(p => new PetDetailModel(p)).ToList();

        // Act
        var result = petController.Index();
        var okResult = result as OkObjectResult;
        var actualContent = okResult.Value as List<PetDetailModel>;

        // Assert
        _petLogicMock.VerifyAll();
        CollectionAssert.AreEqual(expectedContent, actualContent);
    }

    [TestMethod]
    public void ShowOkTest()
    {
        // Arrange
        List<Pet> pets = new List<Pet>() { new Pet() { Id = 1, Name = "Kila", Age = 2 } };
        _petLogicMock.Setup(l => l.GetById(It.IsAny<int>())).Returns(pets.First());
        var controller = new PetController(_petLogicMock.Object);
        var expectedPetModel = new PetDetailModel(pets.First());

        // Act
        var result = controller.Show(pets.First().Id);
        var okResult = result as OkObjectResult;
        var petModel = okResult.Value as PetDetailModel;

        // Assert
        _petLogicMock.VerifyAll();
        // Aca uso un equality comparer en lugar de basarme en el Equals y GetHashCode de PetDetailModel en sí
        Assert.AreEqual(expectedPetModel, petModel, new PetDetailComparer());
    }

    [TestMethod]
    public void ShowNotFoundTest()
    {
        //Arrange
        _petLogicMock.Setup(l => l.GetById(It.IsAny<int>())).Throws(new NotFoundException());
        var controller = new PetController(_petLogicMock.Object);

        //Act
        var result = controller.Show(1);

        //Assert
        _petLogicMock.VerifyAll();
        Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
    }
}