data "azuread_user" "dan_maxim" {
  user_principal_name = var.dmaxim_upn
}


locals {
  tags = {
    "environment" = var.environment
  }

  key_vault_secret_managers = {
    "dan_maxim" = {
      object_id = data.azuread_user.dan_maxim.object_id
    }
  }
}