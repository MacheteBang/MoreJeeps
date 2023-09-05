resource "azurerm_storage_table" "stable" {
  name                 = "Sightings"
  storage_account_name = azurerm_storage_account.st.name
}
