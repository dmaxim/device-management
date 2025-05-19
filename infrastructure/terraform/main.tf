
resource "azurerm_resource_group" "device_manager" {
  name     = join("-", ["rg", var.namespace, var.environment, var.location_abbreviation])
  location = var.location
  tags     = local.tags

}

resource "azurerm_storage_account" "device_manager" {
  name                     = join("", [var.storage_account_name, var.environment, var.location_abbreviation])
  resource_group_name      = azurerm_resource_group.device_manager.name
  location                 = azurerm_resource_group.device_manager.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
  min_tls_version          = "TLS1_2"


  tags = local.tags
}


data "azurerm_mssql_server" "mxinfo_sql_server" {
  name                = var.sql_server_name
  resource_group_name = var.sql_server_rg_name
}


resource "azurerm_mssql_database" "device_db" {
  name        = var.oltp_database_name
  server_id   = data.azurerm_mssql_server.mxinfo_sql_server.id
  collation   = "SQL_Latin1_General_CP1_CI_AS"
  max_size_gb = 2
  sku_name    = "Basic"

  tags = local.tags
}