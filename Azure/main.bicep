param baseName string = resourceGroup().name
param location string = resourceGroup().location

var loweredName = toLower(baseName)

// Create the Azure Container registry - not included in separate module due to sensitive outputs
resource acr 'Microsoft.ContainerRegistry/registries@2021-09-01' = {
  name: '${loweredName}acr'
  location: location
  sku: {
    name: 'Basic'
  }
  properties: {
    adminUserEnabled: true
  }
}

// Load environment module
module env 'environment.bicep' = {
  name: 'containerAppEnvironment'
  params:{
    baseName: baseName
    location: location
  }
}

// Load Application Insights module
module ai 'ai.bicep' = {
  name: 'applicationInsightsInstance'
  params: {
    baseName: baseName
    location: location
    lawId: env.outputs.lawId
  }
}

// Create configuration pairs
var sharedConfig = [
  {
    name: 'ASPNETCORE_ENVIRONMENT'
    value: 'Development'
  }
  {
    name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
    value: ai.outputs.appInsightsInstrumentationKey
  }
  {
    name: 'APPLICATIONINSIGHTS_CONNECTION_STRING'
    value: ai.outputs.appInsightsConnectionString
  }
]

// Create the service container app
module BeneficiaryNameValidationSvc 'containerapp.bicep' = {
  name: 'BeneficiaryNameValidationSvc'
  params: {
    name: 'BeneficiaryNameValidationSvc'
    location: location
    environmentId: env.outputs.envId
    AcrName: acr.name
    AcrUsername: acr.listCredentials().username
    AcrPassword: acr.listCredentials().passwords[0].value
    externalIngress: true
    transport: 'https'
    envVars: sharedConfig
  }
}
