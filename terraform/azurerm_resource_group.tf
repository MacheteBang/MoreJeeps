resource "azurerm_resource_group" "rg" {
  name     = lower("${var.owner_code}-rg-${local.application_name}")
  location = local.region
}

