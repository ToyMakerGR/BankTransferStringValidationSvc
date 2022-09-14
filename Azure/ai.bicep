// Application Insights module
// https://docs.microsoft.com/en-us/azure/templates/microsoft.insights/components?pivots=deployment-language-bicep

param baseName string
param location string
param lawId string // Log Analytics workspace id

var loweredBaseName = toLower(baseName)

resource ai 'Microsoft.Insights/components@2020-02-02' = {
  name: '${loweredBaseName}ai'
  location: location
  kind: 'web'
  properties:{
    Application_Type: 'web'
    WorkspaceResourceId: lawId

  }
}

output appInsightsInstrumentationKey string = ai.properties.InstrumentationKey
output appInsightsConnectionString string = ai.properties.ConnectionString
