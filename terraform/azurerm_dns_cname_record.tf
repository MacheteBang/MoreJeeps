resource "azurerm_dns_cname_record" "dns_cname_record" {
  name                = "www"
  zone_name           = data.azurerm_dns_zone.dns_zone.name
  resource_group_name = data.azurerm_dns_zone.dns_zone.resource_group_name
  ttl                 = 300
  record              = azurerm_static_site.stapp.default_host_name
}
resource "azurerm_dns_cname_record" "dns_cname_record_api" {
  name                = "api"
  zone_name           = data.azurerm_dns_zone.dns_zone.name
  resource_group_name = data.azurerm_dns_zone.dns_zone.resource_group_name
  ttl                 = 300
  record              = azurerm_windows_function_app.func.default_hostname
}
