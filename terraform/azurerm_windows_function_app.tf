resource "azurerm_windows_function_app" "func" {
  name                       = "${var.owner_code}-func-${local.application_name}"
  resource_group_name        = azurerm_resource_group.rg.name
  location                   = azurerm_resource_group.rg.location
  storage_account_name       = azurerm_storage_account.st.name
  storage_account_access_key = azurerm_storage_account.st.primary_access_key
  service_plan_id            = azurerm_service_plan.plan.id

  app_settings = {
    MoreJeepsTableSettings__ConnectionString   = azurerm_storage_account.st.primary_connection_string
    MoreJeepsTableSettings__SightingsTableName = azurerm_storage_table.stable_sightings.name
    MoreJeepsTableSettings__GamesTableName     = azurerm_storage_table.stable_games.name
  }

  site_config {
    application_insights_key               = azurerm_application_insights.appi.instrumentation_key
    application_insights_connection_string = azurerm_application_insights.appi.connection_string

    cors {
      allowed_origins     = ["*"]
      support_credentials = false
    }
  }
}