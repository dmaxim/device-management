# infrastructure/terraform/variables.tf

variable "namespace" {
  type        = string
  description = "Namespace for resource names"
  default     = "mxinfo-deviceman"
}

variable "environment" {
  type        = string
  description = "Environment used in resource names"
  default     = "poc"
}

variable "location" {
  type        = string
  description = "Azure Region for resources"
  default     = "eastus"
}

variable "location_abbreviation" {
  type        = string
  description = "Azure Region abbreviation used in resource names"
  default     = "eus"
}

variable "sql_server_name" {
  type        = string
  description = "Name of the SQL Server"

}

variable "sql_server_rg_name" {
  type        = string
  description = "Name of the resource group for the SQL Server"

}

variable "oltp_database_name" {
  type        = string
  description = "Name of the OLTP database"
  default     = "DeviceManager"
}

variable "storage_account_name" {
  type        = string
  description = "Name of the storage account"
  default     = "mxinfodevman"
}

variable "dmaxim_upn" {
  type        = string
  description = "UPN for the DMAXIM user"
}
# Backend configuration
variable "subscription_id" {
  type        = string
  description = "Azure Subscription ID"

}
