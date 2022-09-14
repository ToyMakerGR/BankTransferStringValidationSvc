// Container app module
// https://docs.microsoft.com/en-us/azure/templates/microsoft.app/containerapps?pivots=deployment-language-bicep

// General settings
param name string
param location string
param environmentId string

// Container image ref
param containerImage string = 'mcr.microsoft.com/mcr/hello-world:latest'

// Environment variables
param envVars array = []

// ACR
param AcrName string
param AcrUsername string
@secure()
param AcrPassword string

// Min/max number of replicas
param minReplicas int = 0
param maxReplicas int = 3

// Networking
param externalIngress bool = false
param targetPort int = 80
param transport string = 'http'
param allowInsecure bool = false

var loweredName = toLower(name)

resource containerApp 'Microsoft.App/containerApps@2022-03-01' = {
  name: loweredName
  location: location
  properties: {
    managedEnvironmentId: environmentId
    configuration: {
      dapr:{
        enabled: true
        appId: name
        appPort: targetPort
        appProtocol: 'http'
      }
      secrets:[
        {
          name: 'container-registry-password'
          value: AcrPassword
        }
      ]
      registries:[
        {
          server: AcrName
          username: AcrUsername
          passwordSecretRef: 'container-registry-password'
        }
      ]
      activeRevisionsMode: 'Single'
    }
    template:{
      containers:[
        {
          image: containerImage
          name: loweredName
          env: envVars
        }
      ]
      scale:{
        minReplicas: minReplicas
        maxReplicas: maxReplicas
      }
    }
  }
}
