using OpenAI.Chat;

namespace MxInfo.DeviceManager.Agent.Business.DeviceManagerFunctions;

public static class FunctionRegistry
{
    public static readonly ChatTool GetDeviceInfoTool = ChatTool.CreateFunctionTool(
        functionName: nameof(GetDeviceInfo),
        functionDescription: "Get information about a device",
        functionParameters: BinaryData.FromString("""
                                                  {
                                                   "type":  "object",
                                                   "properties": {
                                                        "serialNumber": {
                                                            "type": "string",
                                                            "description": "The serial number of the device"
                                                        }
                                                    },
                                                  "required": ["serialNumber"]
                                                  }
                                                  """
        ));
        
    public static readonly ChatTool GetDeviceNetworkInfoTool = ChatTool.CreateFunctionTool(
        functionName: nameof(GetDeviceNetworkInfo),
        functionDescription: "Get network information about a device",
        functionParameters: BinaryData.FromString("""
                                                  {
                                                   "type":  "object",
                                                   "properties": {
                                                        "serialNumber": {
                                                            "type": "string",
                                                            "description": "The serial number of the device"
                                                        }
                                                    },
                                                  "required": ["serialNumber"]
                                                  }
                                                  """
        ));

    public static string GetDeviceInfo(string serialNumber)
    {
        return "Device Info";
    }
    
    public static string GetDeviceNetworkInfo(string serialNumber)
    {
        return "Device Network Info";
    }
}