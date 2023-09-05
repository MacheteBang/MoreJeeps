resource "azurerm_static_site_custom_domain" "stapp_domain" {
  static_site_id  = azurerm_static_site.stapp.id
  domain_name     = data.azurerm_dns_zone.dns_zone.name
  validation_type = "dns-txt-token"
}

resource "azurerm_static_site_custom_domain" "stapp_domain_www" {
  static_site_id  = azurerm_static_site.stapp.id
  domain_name     = "www.${data.azurerm_dns_zone.dns_zone.name}"
  validation_type = "cname-delegation"

  depends_on = [
    azurerm_dns_cname_record.dns_cname_record
  ]
}
