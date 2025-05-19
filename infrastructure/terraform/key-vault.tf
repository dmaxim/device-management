
data "azurerm_client_config" "current" {}



resource "azurerm_key_vault" "device_manager_kv" {
  name                      = join("-", ["kv", var.namespace, var.environment])
  location                  = azurerm_resource_group.device_manager.location
  resource_group_name       = azurerm_resource_group.device_manager.name
  sku_name                  = "standard"
  tenant_id                 = data.azurerm_client_config.current.tenant_id
  enable_rbac_authorization = true
  tags                      = local.tags
}

resource "azurerm_role_assignment" "key_vault_manager" {
  for_each           = local.key_vault_secret_managers
  scope              = azurerm_key_vault.device_manager_kv.id
  role_definition_id = "/subscriptions/${data.azurerm_client_config.current.subscription_id}/providers/Microsoft.Authorization/roleDefinitions/b86a8fe4-44ce-4948-aee5-eccb2c155cd7"
  principal_id       = each.value.object_id
}
