resource "azurerm_application_insights" "appi" {
  name                = lower("${var.owner_code}-appi-${local.application_name}")
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  workspace_id        = azurerm_log_analytics_workspace.log.id
  application_type    = "web"
}
