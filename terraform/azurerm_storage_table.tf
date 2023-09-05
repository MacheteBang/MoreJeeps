resource "azurerm_storage_table" "stable_sightings" {
  name                 = "Sightings"
  storage_account_name = azurerm_storage_account.st.name
}
resource "azurerm_storage_table" "stable_games" {
  name                 = "Games"
  storage_account_name = azurerm_storage_account.st.name
}
