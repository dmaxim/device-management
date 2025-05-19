
CREATE TABLE dbo.Device (
    DeviceId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Device_Id PRIMARY KEY CLUSTERED,
    DeviceName VARCHAR(100) NOT NULL,
    DeviceDescription VARCHAR(255),
    DeviceUid UNIQUEIDENTIFIER NOT NULL,
    
)

CREATE TABLE dbo.WifiNetwork (
    WifiNetworkId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_WifiNetwork_Id PRIMARY KEY CLUSTERED,
    WifiNetworkName VARCHAR(100) NOT NULL,
    WifiNetworkDescription VARCHAR(255),
    WifiNetworkUid UNIQUEIDENTIFIER NOT NULL,
)

GO

CREATE TABLE dbo.EthernetNetwork (
    EthernetNetworkId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_EthernetNetwork_Id PRIMARY KEY CLUSTERED,
    EthernetNetworkName VARCHAR(100) NOT NULL,
    EthernetNetworkDescription VARCHAR(255),
    EthernetNetworkUid UNIQUEIDENTIFIER NOT NULL,
)

GO