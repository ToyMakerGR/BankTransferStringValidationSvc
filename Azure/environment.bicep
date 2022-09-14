// Log analytics workspace & Container App environment modules
// https://docs.microsoft.com/en-us/azure/templates/microsoft.operationalinsights/workspaces?pivots=deployment-language-bicep
// https://docs.microsoft.com/en-us/azure/templates/microsoft.app/2022-03-01/managedenvironments?pivots=deployment-language-bicep

param baseName string
param location string

var loweredName = toLower(baseName)

resource law 'Microsoft.OperationalInsights/workspaces@2021-06-01' = {
  name: '${loweredName}law'
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
    retentionInDays: 30
  }
}

resource env 'Microsoft.App/managedEnvironments@2022-03-01' = {
  name: '${loweredName}env'
  location: location
  properties:{
    appLogsConfiguration:{
      destination: 'log-analytics'
      logAnalyticsConfiguration:{
        customerId: law.properties.customerId
        // shared key not used as output so that it's not logged
        // outputs can't be marked as secure
        sharedKey: law.listKeys().primarySharedKey 
      }
    }
  }
}

output envId string = env.id
output lawId string = law.id
