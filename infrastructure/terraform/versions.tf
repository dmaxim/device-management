# infrastructure/azure/versions.tf

terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 4.18.0"
    }
    azuread = {
      source  = "hashicorp/azuread"
      version = "~> 2"
    }
  }

}
