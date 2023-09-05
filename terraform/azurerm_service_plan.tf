resource "azurerm_service_plan" "plan" {
  name                = "${var.owner_code}-plan-${local.application_name}"
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  os_type             = "Windows"
  sku_name            = "Y1"
}
