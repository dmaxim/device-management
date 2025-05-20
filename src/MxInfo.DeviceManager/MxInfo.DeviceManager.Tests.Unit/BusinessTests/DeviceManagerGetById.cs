using MxInfo.DeviceManager.Domain.Exceptions;
using MxInfo.DeviceManager.Tests.Unit.Infrastructure;

namespace MxInfo.DeviceManager.Tests.Unit.BusinessTests;


[Collection(nameof(BusinessTestFixtureCollection))]
public class DeviceManagerGetById(BusinessTestFixture fixture)
{
    [Fact]
    public void Returns_Device_By_Id()
    {
        var deviceManager = fixture.GetDeviceManager();
        var device = deviceManager.GetById(fixture.TestDeviceId);
        Assert.NotNull(device);
        
    }

    [Fact]
    public void Throws_Expected_Not_Found_Exception_For_Device_That_Does_Not_Exist()
    {
        var deviceManager = fixture.GetDeviceManager();
        _ = Assert.ThrowsAsync<MxInfoNotFoundException>(() => deviceManager.GetById(fixture.DeviceIdThatDoesNotExist));
    }
}