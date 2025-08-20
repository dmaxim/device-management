# device-management

Publish Pact Contract

````
$HOME/storage/pact/bin/pact-broker publish src/MxInfo.DeviceManager/pacts/ApiClient-ConfigurationService.json --consumer-app-version 1.0.0 --branch main --broker-base-url https://mxinformatics-llc.pactflow.io --broker-token <token>
````

https://mxinformatics-llc.pactflow.io/pacts/provider/ConfigurationService/consumer/ApiClient/version/1.0.0

Publish with base auth

````
$HOME/storage/pact/bin/pact-broker publish src/MxInfo.DeviceManager/pacts/ApiClient-ConfigurationService.json --consumer-app-version 1.0.0 --branch main --broker-base-url http://localhost:8080 --broker-username dmaxim --broker-password MxGrapple6+6=12
````