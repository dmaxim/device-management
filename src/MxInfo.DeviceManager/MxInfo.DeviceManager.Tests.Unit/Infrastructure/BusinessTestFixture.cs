using Moq;
using MxInfo.DeviceManager.Business.Managers;
using MxInfo.DeviceManager.Domain.Exceptions;
using MxInfo.DeviceManager.Domain.Models;
using MxInfo.DeviceManager.Domain.Repositories;

namespace MxInfo.DeviceManager.Tests.Unit.Infrastructure;


/// <summary>
/// Test fixture for validating business logic
/// </summary>
public class BusinessTestFixture
{
 
    public int TestDeviceId { get; } = 1;
    public int DeviceIdThatDoesNotExist { get;  } = 9999;  
    public IDeviceManager GetDeviceManager()
    {
        var mockDeviceRepository = GetMockDeviceRepository();
        return new Business.Managers.DeviceManager(mockDeviceRepository.Object);
    }


    private Mock<IDeviceRepository> GetMockDeviceRepository()
    {
        var mockDeviceRepository = new Mock<IDeviceRepository>();
        mockDeviceRepository.Setup(repo => repo.GetById(It.Is<int>(id => id == TestDeviceId)))
            .ReturnsAsync(new Device
            {
                Id = TestDeviceId,
                Name = "Test Device",
                Description = "Test Device Description",
                Uid = Guid.NewGuid()
            });
        
        mockDeviceRepository.Setup(repo => repo.GetById(It.Is<int>(id => id == DeviceIdThatDoesNotExist)))
            .ThrowsAsync(new MxInfoNotFoundException("Device not found"));
        return mockDeviceRepository;
    }
}