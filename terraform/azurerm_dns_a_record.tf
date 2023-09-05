resource "azurerm_dns_a_record" "dns_a_record" {
  name                = "@"
  zone_name           = data.azurerm_dns_zone.dns_zone.name
  resource_group_name = data.azurerm_dns_zone.dns_zone.resource_group_name
  ttl                 = 300
  target_resource_id  = azurerm_static_site.stapp.id
}
