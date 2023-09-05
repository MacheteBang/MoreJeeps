resource "azurerm_static_site" "stapp" {
  name                = lower("${var.owner_code}-stapp-${local.application_name}")
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
}
